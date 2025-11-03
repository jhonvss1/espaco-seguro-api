using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services
{
    public interface ICardService
    {
        Task<ConteudoCard> Criar(ConteudoCard usuario);
        Task<ConteudoCard> Atualizar(ConteudoCard usuario, Guid id);
        Task<List<ConteudoCard>> ObterTodosUsuarios();
        Task<ConteudoCard> ObterPorId(Guid id);
        Task<ConteudoCard> Deletar(Guid id);
    }
}
