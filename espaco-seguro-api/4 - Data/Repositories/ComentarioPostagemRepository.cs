using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories;

public class ComentarioPostagemRepository(AppDbContext context)  : IComentarioPostagemRepository
{
    public async Task<ComentarioPostagem> Criar(ComentarioPostagem comentarioPostagem)
    {
          await context.ComentarioPostagens.AddAsync(comentarioPostagem);
          await context.SaveChangesAsync();
         return comentarioPostagem;
    }

    public async Task<List<ComentarioPostagem>> ObterTodos()
    { 
        var comentarios = await context.ComentarioPostagens.AsNoTracking().ToListAsync();
        return comentarios;
    }

    public async Task<ComentarioPostagem?> Deletar(Guid comentarioId)
    {
        var comentario = await context.ComentarioPostagens.FindAsync(comentarioId);
        if (comentario != null)
        {
            context.ComentarioPostagens.Remove(comentario);
        }
        return  comentario;
    }
}