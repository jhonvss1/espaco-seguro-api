using System.Linq;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories;

public class MensagemChatRepository(AppDbContext context) : IMensagemChatRepository
{
    public async Task<MensagemChat> Criar(MensagemChat mensagem)
    {
        await context.MensagemChats.AddAsync(mensagem);
        await context.SaveChangesAsync();
        return mensagem;
    }

    public async Task<List<MensagemChat>> ObterPorSessao(Guid sessaoId)
    {
        return await context.MensagemChats
            .AsNoTracking()
            .Where(m => m.SessaoId == sessaoId)
            .OrderBy(m => m.DataEnvio)
            .ToListAsync();
    }

    public async Task<MensagemChat?> ObterPorId(Guid mensagemId)
    {
        return await context.MensagemChats
            .FirstOrDefaultAsync(m => m.Id == mensagemId);
    }

    public async Task<MensagemChat> Atualizar(MensagemChat mensagem)
    {
        context.MensagemChats.Update(mensagem);
        await context.SaveChangesAsync();
        return mensagem;
    }
}
