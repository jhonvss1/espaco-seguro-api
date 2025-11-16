using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._3___Domain.Services
{
    public class CardService(ICardRepository cardRepository) : ICardService
    {
        public async Task<ConteudoCard> Criar(ConteudoCard card, Guid autorId)
        {
            return await cardRepository.Criar(card, autorId);
        }

        public async Task EnviarParaRevisao(Guid cardId, Guid userId)
        {
             await cardRepository.EnviarParaRevisao(cardId, userId);
        }

        public async Task IniciarRevisao(Guid cardId, Guid userId)
        {
            await cardRepository.IniciarRevisao(cardId, userId);
        }

        public async Task Publicar(Guid cardId, Guid userId)
        {
            await  cardRepository.Publicar(cardId, userId);
        }

        public async Task Arquivar(Guid cardId, Guid userId)
        {
            await cardRepository.Arquivar(cardId, userId);
        }

        public async Task<ConteudoCard> Atualizar(ConteudoCard card, Guid cardId)
        {
            return await cardRepository.Atualizar(card, cardId);
        }

        public async Task<ConteudoCard> ObterPorId(Guid id)
        {
            return await cardRepository.ObterPorId(id);
        }

        public async Task<IReadOnlyList<ConteudoCard>> ObterTodos()
        {
            return await cardRepository.ObterTodos();
        }

        public async Task Remover(Guid id, Guid userId)
        {
            await cardRepository.Remover(id, userId);
        }
    }
}
