using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp
{
    public interface ICardServiceApp
    {
        Task<CardResponse> Criar(CardResquestVm cardResquestVm, Guid usuarioId);
        Task EnviarParaRevisao(Guid cardId, Guid usuarioId);
        Task IniciarRevisao(Guid cardId, Guid usuarioId);
        Task Publicar(Guid cardId, Guid usuarioId);
        Task Arquivar(Guid cardId, Guid usuarioId);
        Task<CardResponse> Atualizar(CardResquestVm cardResquestVm, Guid cardId);
        Task<CardResponse> ObterPorId(Guid id);
        Task<List<CardResponse>> ObterTodos();
        Task Remover(Guid id, Guid usuarioId);
    }
}
