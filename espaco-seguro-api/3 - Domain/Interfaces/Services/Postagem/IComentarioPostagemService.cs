using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services;

public interface IComentarioPostagemService
{
    Task<ComentarioPostagem> Criar(ComentarioPostagem comentarioPostagem);
    
    Task<List<ComentarioPostagem>> ObterTodos();
    
    Task<ComentarioPostagem?> Deletar(Guid comentarioId);
}