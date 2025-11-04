using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp
{
    public interface ICardServiceApp
    {
        Task<CardResponse> Criar(CardResquestVm cardVm);
        Task<CardResponse> ObterPorId(Guid id);
        Task<CardResponse> Atualizar(CardResquestVm cardVm, Guid id);
        Task<List<CardResponse>> ObterTodos();  
        Task<CardResponse> Remover(Guid id);
    }
}
