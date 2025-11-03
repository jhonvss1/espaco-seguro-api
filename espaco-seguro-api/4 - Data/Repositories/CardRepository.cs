using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories
{
    public class CardRepository(AppDbContext context) : ICardRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ConteudoCard> Criar(ConteudoCard card)
        {
            await _context.ConteudoCards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<ConteudoCard> Atualizar(ConteudoCard card, Guid id)
        {
           var existente = await _context.ConteudoCards.FirstOrDefaultAsync(x => x.Id == id);
            if (existente is null)
                throw new KeyNotFoundException("Card não encontrado para atualização.");

            var entry = _context.Entry(existente);

            var teste = new Helpers.Helpers();
            
            // AtualizaCamposPreenchidos(card, existente, entry); aqui tem que ser um metodo que atualiza as entidades proprias do card

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<ConteudoCard> ObterPorId(Guid id)
        {
            var card = await _context.ConteudoCards.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return card;
        }

        public async Task<List<ConteudoCard>> ObterTodos()
        {
            var cards = await _context.ConteudoCards.AsNoTracking().ToListAsync();
            return cards;
        }

        public async Task<ConteudoCard> Remover(Guid id)
        {
            var card = await _context.ConteudoCards.FirstOrDefaultAsync(c => c.Id == id);
            _context.ConteudoCards.Remove(card);
            
            await _context.SaveChangesAsync();
            return card;
        }
    }
}
