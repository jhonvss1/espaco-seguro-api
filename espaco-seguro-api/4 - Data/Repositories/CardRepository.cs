using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories
{
    public class CardRepository(AppDbContext context) : ICardRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ConteudoCard> Criar(ConteudoCard conteudoCard, Guid usuarioId)
        {
            conteudoCard.CriadoPor(usuarioId);
            await _context.ConteudoCards.AddAsync(conteudoCard);
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

        public async Task<ConteudoCard> Atualizar(ConteudoCard conteudoCard, Guid id, Guid userId)
        {
            var atual = await context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == id);
            // aqui as regras de atualização (checar autor, status permitido, etc.)
            atual.Titulo = conteudoCard.Titulo;
            atual.Resumo = conteudoCard.Resumo;
            atual.Corpo = conteudoCard.Corpo;
            atual.Tipo = conteudoCard.Tipo;
            atual.UrlMidia = conteudoCard.UrlMidia;
            atual.Tags = conteudoCard.Tags;
            atual.DataAtualizacao = DateTime.UtcNow;
            context.Update(atual);
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
            // regra: quem pode deletar?
              context.ConteudoCards.Remove(card);
              return  card;
        }
        
    }
}
