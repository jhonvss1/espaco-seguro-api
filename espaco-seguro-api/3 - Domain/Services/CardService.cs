using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._3___Domain.Services
{
    public class CardService(ICardRepository cardRepository) : ICardService
    {
        public async Task<ConteudoCard> Criar(ConteudoCard card)
        {
            if(card is null)
                throw new DomainValidationException("O conteúdo do card não pode ser nulo.");
            return await cardRepository.Criar(card);
        }

        public Task<ConteudoCard> Atualizar(ConteudoCard conteudoCard, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ConteudoCard>> ObterTodosCards()
        {
            throw new NotImplementedException();
        }
        
        public async Task<ConteudoCard> ObterPorId(Guid id)
        {
            var card = await cardRepository.ObterPorId(id);
            return card;
        }

        public Task<ConteudoCard> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
