using System.Linq;
using espaco_seguro_api._3___Domain.Chat;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories;

public class SessaoChatRepository(AppDbContext context) : ISessaoChatRepository
{
    public async Task<SessaoChat> Criar(SessaoChat sessao)
    {
        await context.SessaoChats.AddAsync(sessao);
        await context.SaveChangesAsync();
        return sessao;
    }

    public async Task<SessaoChat?> ObterPorId(Guid id)
    {
        return await context.SessaoChats
            .Include(s => s.Mensagens)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<SessaoChat?> ObterSessaoAtiva(Guid usuarioId, TipoChat tipoChat)
    {
        return await context.SessaoChats
            .AsNoTracking()
            .FirstOrDefaultAsync(s =>
                s.UsuarioId == usuarioId &&
                s.TipoChat == tipoChat &&
                s.StatusChat == StatusChat.Ativo);
    }

    public async Task<List<SessaoChat>> ObterPorUsuario(Guid usuarioId)
    {
        return await context.SessaoChats
            .Include(s => s.Mensagens)
            .AsNoTracking()
            .Where(s => s.UsuarioId == usuarioId)
            .OrderByDescending(s => s.IniciadoEm)
            .ToListAsync();
    }

    public async Task<SessaoChat> Atualizar(SessaoChat sessao)
    {
        context.SessaoChats.Update(sessao);
        await context.SaveChangesAsync();
        return sessao;
    }
}
