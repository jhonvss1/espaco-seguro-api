using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp;

public interface IPostagemServiceApp
{
    Task<PostagemReponse> Criar(CriarPostagemRequestVm criarPostagemVm);
    Task<PostagemReponse> ObterPorId(Guid id);
    Task<PostagemReponse> Atualizar(CriarPostagemRequestVm criarPostagemVm, Guid id);
    Task <List<PostagemReponse>> ObterTodas();
    Task<PostagemReponse> Remover(Guid id);
}