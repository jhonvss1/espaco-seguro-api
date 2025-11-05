using espaco_seguro_api._2___Application.Request.ComentarioPostagem;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp.ComentarioPostagem;

public interface IComentarioPostagemServiceApp
{
    Task<ComentarioPostagemResponse> Criar(ComentarioPostagemRequestVm comentarioPostagem);
    
    Task<List<ComentarioPostagemResponse>> ObterTodos();
    
    Task<ComentarioPostagemResponse?> Deletar(Guid comentarioId);
}