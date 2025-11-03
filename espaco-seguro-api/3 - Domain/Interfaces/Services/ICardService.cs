using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services
{
    public interface ICardService
    {
        Task<ConteudoCard> Criar(ConteudoCard conteudoCard);
        Task<ConteudoCard> Atualizar(ConteudoCard conteudoCard, Guid id);
        Task<List<ConteudoCard>> ObterTodosCards();
        Task<ConteudoCard> ObterPorId(Guid id);
        Task<ConteudoCard> Deletar(Guid id);
    }
}
