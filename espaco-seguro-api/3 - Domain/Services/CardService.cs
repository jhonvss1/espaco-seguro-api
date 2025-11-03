using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._3___Domain.Services
{
    public class CardService(ICardRepository cardRepository) : ICardService
    {
        public async Task<Card> Criar(Card card)
        {
            if(card is null)
                throw new DomainValidationException("O conteúdo do card não pode ser nulo.");
            return await cardRepository.Criar(card);
        }

        public async Task<Card> ObterPorId(Guid id)
        {
            var card = await cardRepository.ObterPorId(id);
            return card;
        }

        public Task<List<Card>> ObterTodosCards()
        {
            throw new NotImplementedException();
        }

        public Task<Card> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
