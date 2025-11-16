using espaco_seguro_api._3___Domain.Chat;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Repositories;

public interface ISessaoChatRepository
{
    Task<SessaoChat> Criar(SessaoChat sessao);
    Task<SessaoChat?> ObterPorId(Guid id);
    Task<SessaoChat?> ObterSessaoAtiva(Guid usuarioId, TipoChat tipoChat);
    Task<List<SessaoChat>> ObterPorUsuario(Guid usuarioId);
    Task<SessaoChat> Atualizar(SessaoChat sessao);
}
