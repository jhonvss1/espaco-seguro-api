using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Repositories;

public interface IPostagemRepository
{
    Task<Postagem> Criar(Postagem postagem);
    Task<Postagem> Atualizar(Postagem postagem, Guid id);
    Task<Postagem> ObterPorId(Guid id);
    Task<(Postagem postagem, IReadOnlyList<ComentarioPostagem> Comentarios, int TotalComentarios)> ObterPostagemComComentarios(Guid id);
    Task<List<Postagem>> ObterTodasPostagens();
    Task<Postagem> Remover(Guid id);
}