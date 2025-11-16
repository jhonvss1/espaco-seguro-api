using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Repositories;

public interface IMensagemChatRepository
{
    Task<MensagemChat> Criar(MensagemChat mensagem);
    Task<List<MensagemChat>> ObterPorSessao(Guid sessaoId);
    Task<MensagemChat?> ObterPorId(Guid mensagemId);
    Task<MensagemChat> Atualizar(MensagemChat mensagem);
}
