using espaco_seguro_api._3___Domain.Entities;



namespace espaco_seguro_api._3___Domain.Interfaces.Repositories
{
    public interface ICardRepository
    {
        Task<ConteudoCard> Criar(ConteudoCard conteudoCard);
        Task<ConteudoCard> Atualizar(ConteudoCard conteudoCard, Guid id);
        Task<ConteudoCard> ObterPorId(Guid id);
        Task<List<ConteudoCard>> ObterTodos();
        Task<ConteudoCard> Remover(Guid id);
    }
}
