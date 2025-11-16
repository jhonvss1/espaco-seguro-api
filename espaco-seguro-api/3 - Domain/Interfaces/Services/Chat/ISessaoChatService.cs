using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services.Chat;

public interface ISessaoChatService
{
    Task<SessaoChat> Criar(SessaoChat sessao);
    Task<SessaoChat> ObterPorId(Guid sessaoId);
    Task<List<SessaoChat>> ObterPorUsuario(Guid usuarioId);
    Task<SessaoChat> Encerrar(Guid sessaoId);
}
