using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._4___Data.Repositories
{
    public class CardRepository(AppDbContext context) : ICardRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ConteudoCard> Criar(ConteudoCard card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<ConteudoCard> Atualizar(ConteudoCard card, Guid id)
        {
           var existente = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existente is null)
                throw new KeyNotFoundException("Card não encontrado para atualização.");

            var entry = _context.Entry(existente);
            AtualizaCamposPreenchidos(card, existente, entry);

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
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return card;
        }
    }
}
