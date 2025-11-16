using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Chat;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services.Chat;

namespace espaco_seguro_api._3___Domain.Services.Chat;

public class SessaoChatService(
    ISessaoChatRepository sessaoChatRepository,
    IUsuarioRepository usuarioRepository) : ISessaoChatService
{
    public async Task<SessaoChat> Criar(SessaoChat sessao)
    {
        if (sessao is null)
            throw new DomainValidationException("Dados da sessão não foram informados.");

        if (!sessao.Anonima && (!sessao.UsuarioId.HasValue || sessao.UsuarioId == Guid.Empty))
            throw new DomainValidationException("Usuário é obrigatório para sessões identificadas.");

        if (sessao.TipoChat == 0)
            throw new DomainValidationException("Tipo de chat é obrigatório.");

        sessao.StatusChat = StatusChat.Ativo;
        sessao.IniciadoEm = DateTime.UtcNow;
        sessao.EncerradoEm = null;

        if (sessao.Anonima)
        {
            sessao.UsuarioId = null;
        }
        else if (sessao.UsuarioId.HasValue)
        {
            var usuario = await usuarioRepository.ObterPorId(sessao.UsuarioId.Value)
                          ?? throw new DomainValidationException("Usuário informado não existe.");

            if (usuario.StatusUsuario != StatusUsuario.Ativo)
                throw new DomainValidationException("Somente usuários ativos podem abrir sessões.");

            var existente = await sessaoChatRepository.ObterSessaoAtiva(usuario.Id, sessao.TipoChat);
            if (existente is not null)
                throw new DomainValidationException("Já existe uma sessão ativa para este tipo de conversa.");
        }

        return await sessaoChatRepository.Criar(sessao);
    }

    public async Task<SessaoChat> ObterPorId(Guid sessaoId)
    {
        if (sessaoId == Guid.Empty)
            throw new DomainValidationException("Sessão inválida.");

        var sessao = await sessaoChatRepository.ObterPorId(sessaoId);
        if (sessao is null)
            throw new DomainValidationException("Sessão não encontrada.");

        return sessao;
    }

    public async Task<List<SessaoChat>> ObterPorUsuario(Guid usuarioId)
    {
        if (usuarioId == Guid.Empty)
            throw new DomainValidationException("Usuário inválido.");

        await GarantirUsuarioExiste(usuarioId);
        return await sessaoChatRepository.ObterPorUsuario(usuarioId);
    }

    public async Task<SessaoChat> Encerrar(Guid sessaoId)
    {
        var sessao = await ObterPorId(sessaoId);

        if (sessao.StatusChat != StatusChat.Ativo)
            throw new DomainValidationException("Somente sessões ativas podem ser encerradas.");

        sessao.StatusChat = StatusChat.Fechado;
        sessao.EncerradoEm = DateTime.UtcNow;

        return await sessaoChatRepository.Atualizar(sessao);
    }

    private async Task GarantirUsuarioExiste(Guid usuarioId)
    {
        var usuario = await usuarioRepository.ObterPorId(usuarioId);
        if (usuario is null)
            throw new DomainValidationException("Usuário não encontrado.");
    }
}
