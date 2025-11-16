using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Chat;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services.Chat;

namespace espaco_seguro_api._3___Domain.Services.Chat;

public class MensagemChatService(
    IMensagemChatRepository mensagemChatRepository,
    ISessaoChatRepository sessaoChatRepository,
    IUsuarioRepository usuarioRepository) : IMensagemChatService
{
    public async Task<MensagemChat> Enviar(MensagemChat mensagem)
    {
        if (mensagem is null)
            throw new DomainValidationException("Mensagem inválida.");

        if (mensagem.SessaoId == Guid.Empty)
            throw new DomainValidationException("Sessão do chat não foi informada.");

        if (string.IsNullOrWhiteSpace(mensagem.Conteudo))
            throw new DomainValidationException("Conteúdo da mensagem é obrigatório.");

        if (mensagem.Conteudo.Length > 2000)
            throw new DomainValidationException("Mensagem ultrapassa o limite de 2000 caracteres.");

        var sessao = await sessaoChatRepository.ObterPorId(mensagem.SessaoId)
                    ?? throw new DomainValidationException("Sessão do chat não foi encontrada.");

        if (sessao.StatusChat != StatusChat.Ativo)
            throw new DomainValidationException("Não é possível enviar mensagem para sessão encerrada.");

        if (!sessao.Anonima && (!mensagem.RemetenteId.HasValue || mensagem.RemetenteId == Guid.Empty))
            throw new DomainValidationException("Remetente é obrigatório para sessões identificadas.");

        if (mensagem.RemetenteId.HasValue && mensagem.RemetenteId != Guid.Empty)
        {
            var remetente = await usuarioRepository.ObterPorId(mensagem.RemetenteId.Value)
                            ?? throw new DomainValidationException("Remetente não encontrado.");

            if (remetente.StatusUsuario is StatusUsuario.Bloqueado or StatusUsuario.Inativo)
                throw new DomainValidationException("Somente usuários ativos podem enviar mensagens.");
        }

        mensagem.TipoMensagem = mensagem.TipoMensagem == 0 ? TipoMensagem.Texto : mensagem.TipoMensagem;
        mensagem.DataEnvio = DateTime.UtcNow;
        mensagem.DataLida = null;
        mensagem.Lida = false;

        return await mensagemChatRepository.Criar(mensagem);
    }

    public async Task<List<MensagemChat>> ObterPorSessao(Guid sessaoId)
    {
        if (sessaoId == Guid.Empty)
            throw new DomainValidationException("Sessão inválida.");

        await GarantirSessaoExiste(sessaoId);
        return await mensagemChatRepository.ObterPorSessao(sessaoId);
    }

    public async Task<MensagemChat> MarcarComoLida(Guid mensagemId)
    {
        if (mensagemId == Guid.Empty)
            throw new DomainValidationException("Mensagem inválida.");

        var mensagem = await mensagemChatRepository.ObterPorId(mensagemId)
                       ?? throw new DomainValidationException("Mensagem não encontrada.");

        mensagem.Lida = true;
        mensagem.DataLida = DateTime.UtcNow;

        return await mensagemChatRepository.Atualizar(mensagem);
    }

    private async Task GarantirSessaoExiste(Guid sessaoId)
    {
        var sessao = await sessaoChatRepository.ObterPorId(sessaoId);
        if (sessao is null)
            throw new DomainValidationException("Sessão não encontrada.");
    }
}
