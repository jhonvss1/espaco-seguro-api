using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services;

public interface IPostagemService
{
    Task<Postagem> Criar(Postagem postagem);
    Task<Postagem> Atualizar(Postagem postagem, Guid id);
    Task<List<Postagem>> ObterTodasPostagens();
    Task<Postagem> ObterPorId(Guid id);
    Task<Postagem> Deletar(Guid id);
}