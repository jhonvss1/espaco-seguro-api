using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._4___Data.Repositories;

public class CurtidaPostagemRepository(AppDbContext context) : ICurtidaPostagemRepository
{
    
    public async Task<int> CurtirAsync(Guid postagemId, Guid usuarioId)
    {
        var insereCurtida = await context.Database.ExecuteSqlRawAsync(@"
            INSERT INTO curtida_postagem (id, postagem_id, usuario_id, data_criacao, data_remocao)
            VALUES ({0}, {1}, {2}, now() at time zone 'utc', NULL)
            ON CONFLICT (postagem_id, usuario_id) DO NOTHING;",
            Guid.NewGuid(), postagemId, usuarioId);
        if (insereCurtida == 1)
        {
            await context.Database.ExecuteSqlRawAsync(@"
                UPDATE postagem SET contagem_curtidas = contagem_curtidas + 1
                WHERE id = {0}", postagemId);
        }
        
        var count = await context.Postagens.Where(p => p.Id == postagemId)
            .Select(p => p.ContagemCurtidas)
            .SingleAsync();
        
        return count;
    }
    
    public async Task<int> DescurtirAsync(Guid postagemId, Guid usuarioId)
    {
        var removeCurtida = await context.Database.ExecuteSqlRawAsync(@"
        UPDATE curtida_postagem
        SET data_remocao = now() at time zone 'utc'
        WHERE postagem_id = {0}
        AND usuario_id = {1}
        AND data_remocao IS NULL", postagemId, usuarioId);

        if (removeCurtida == 1)
        {
            await context.Database.ExecuteSqlRawAsync(@"
            UPDATE postagem 
            SET contagem_curtidas = GREATEST(contagem_curtidas - 1, 0)
            WHERE id = {0}
        ",  postagemId);
        }
        
        var count = await context.Postagens
            .Where(p => p.Id == postagemId)
            .Select(p => p.ContagemCurtidas)
            .SingleAsync();
        
        return count;
    }
}