using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories
{
    public class CardRepository(AppDbContext context) : ICardRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ConteudoCard> Criar(ConteudoCard conteudoCard, Guid autorId)
        {
            conteudoCard.CriadoPor(autorId);
            
            _context.ConteudoCards.Add(conteudoCard);
            await _context.SaveChangesAsync();
            return conteudoCard;
        }

        public async Task EnviarParaRevisao(Guid cardId, Guid usuarioId)
        {
            var card  = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == cardId);
            card.EnviarParaRevisao(usuarioId, _ => true);
            context.ConteudoCards.Update(card);
            await context.SaveChangesAsync();
        }

        public async Task IniciarRevisao(Guid cardId, Guid usuarioId)
        {
            var card  = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == cardId);
            card.IniciarRevisao(usuarioId, _ => true);
            context.ConteudoCards.Update(card);
            await context.SaveChangesAsync();
        }

        public async Task Publicar(Guid cardId, Guid usuarioId)
        {
            var card  = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == cardId);
            card.Publicar(usuarioId, _ => true);
            context.ConteudoCards.Update(card);
            await context.SaveChangesAsync();
        }

        public async Task Arquivar(Guid cardId, Guid usuarioId)
        {
            var card  = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == cardId);
            card.Arquivar(usuarioId, _ => true);
            context.ConteudoCards.Update(card);
            await context.SaveChangesAsync();
        }

        public async Task<ConteudoCard> Atualizar(ConteudoCard conteudoCard, Guid cardId)
        {
            var atual = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == cardId);

            AtualizarCamposPreenchidos(atual, conteudoCard);
            
            context.Update(atual);
            await context.SaveChangesAsync();
            return atual;
        }

        public async Task<ConteudoCard> ObterPorId(Guid id)
        {
            var card = await _context.ConteudoCards.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return card;
        }

        async Task<IReadOnlyList<ConteudoCard>> ICardRepository.ObterTodos()
        {
            var cards = await _context.ConteudoCards.AsNoTracking().ToListAsync();
            return cards;
        }

        public async Task<ConteudoCard> Remover(Guid id, Guid userId)
        {
            var card = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == id);
              context.ConteudoCards.Remove(card);
              return  card;
        }


        private void AtualizarCamposPreenchidos(ConteudoCard existente, ConteudoCard novo)
        {
            if (existente == null)
                throw new DomainValidationException("Card não existente.");

            if (novo == null)
                throw new DomainValidationException("Não há informações para serem atualizadas");
            
            if(novo.Titulo != null)
                existente.Titulo = novo.Titulo;
            
            if(novo.Corpo!= null)
                existente.Corpo = novo.Corpo;
            if(novo.Resumo != null)
                existente.Resumo = novo.Resumo;
            if(novo.UrlMidia != null)
                existente.UrlMidia = novo.UrlMidia;
            if (novo.Status != null)
                existente.Status = novo.Status;
        }
        
    }
}
