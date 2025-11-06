using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp;

public interface IPostagemServiceApp
{
    Task<PostagemResponse> Criar(CriarPostagemRequestVm criarPostagemVm);
    Task<PostagemResponse> ObterPorId(Guid id);
    Task<PostagemCompletaResponse> ObterPostagemComComentarios(Guid id);
    Task<PostagemResponse> Atualizar(CriarPostagemRequestVm criarPostagemVm, Guid id);
    Task <List<PostagemResponse>> ObterTodas();
    Task<PostagemResponse> Remover(Guid id);
}