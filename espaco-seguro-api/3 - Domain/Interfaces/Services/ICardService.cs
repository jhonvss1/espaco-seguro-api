using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services
{
    public interface ICardService
    {
        Task<ConteudoCard> Criar(ConteudoCard card, Guid autorId);
        Task EnviarParaRevisao(Guid cardId, Guid userId);
        Task IniciarRevisao(Guid cardId, Guid userId);
        Task Publicar(Guid cardId, Guid userId);
        Task Arquivar(Guid cardId, Guid userId);
        Task<ConteudoCard> Atualizar(ConteudoCard card, Guid cardid);
        Task<ConteudoCard> ObterPorId(Guid id);
        Task<IReadOnlyList<ConteudoCard>> ObterTodos();
        Task Remover(Guid id, Guid userId);
    }
}
