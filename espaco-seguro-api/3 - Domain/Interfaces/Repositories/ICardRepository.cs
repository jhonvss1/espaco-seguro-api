using espaco_seguro_api._3___Domain.Entities;



namespace espaco_seguro_api._3___Domain.Interfaces.Repositories
{
    public interface ICardRepository
    {
        Task<ConteudoCard> Criar(ConteudoCard conteudoCard, Guid usuarioId);
        Task EnviarParaRevisao(Guid cardId, Guid usuarioId);
        Task IniciarRevisao(Guid cardId, Guid usuarioId);
        Task Publicar(Guid cardId, Guid usuarioId);
        Task Arquivar(Guid cardId, Guid usuarioId);
        Task<ConteudoCard> Atualizar(ConteudoCard conteudoCard, Guid cardId);
        Task<ConteudoCard> ObterPorId(Guid id);
        Task<IReadOnlyList<ConteudoCard>> ObterTodos();
        Task<ConteudoCard> Remover(Guid id, Guid usuarioId);
    }
}
