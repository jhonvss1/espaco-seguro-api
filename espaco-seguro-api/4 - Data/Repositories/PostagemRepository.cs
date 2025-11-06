using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace espaco_seguro_api._4___Data.Repositories;

public class PostagemRepository(AppDbContext context) : IPostagemRepository
{
    public async Task<Postagem> Criar(Postagem postagem)
    {
        if (postagem == null)
            throw new ArgumentNullException(nameof(postagem));
        
        await context.Postagens.AddAsync(postagem);
        await context.SaveChangesAsync();
        return postagem;
    }

    public async Task<Postagem> Atualizar(Postagem postagem, Guid id)
    {
        var existente = await context.Postagens.FirstOrDefaultAsync(x => x.Id == id);
        if (existente is null)
            throw new KeyNotFoundException("Postagem não encontrada para atualização.");
    
        var entry = context.Entry(existente);

        AtualizaCamposPreenchidosDaPostagem(postagem, existente, entry);

        await context.SaveChangesAsync();
        return existente;
        
    }

    public async Task<Postagem> ObterPorId(Guid id)
    {
        if(id == Guid.Empty)
            throw new ArgumentNullException();
        
        var postagem = await context.Postagens.FirstOrDefaultAsync(x => x.Id == id);

        if (postagem == null)
            return null;
        
        return postagem;
    }

    public async Task<(Postagem postagem, IReadOnlyList<ComentarioPostagem> Comentarios, int TotalComentarios)> 
        ObterPostagemComComentarios(Guid id)
    {
        var postagem = await context.Postagens.FirstOrDefaultAsync(x => x.Id == id);
        if (postagem is null)
            return(null, Array.Empty<ComentarioPostagem>(), 0);

        var totalComentarios = await context.ComentarioPostagens.AsNoTracking()
            .CountAsync(c => c.PostagemId == id 
                             && c.StatusComentarioPostagem == StatusComentarioPostagem.Publicado);

        var comentarios = await context.ComentarioPostagens.AsNoTracking()
            .Where(c => c.PostagemId == id && c.StatusComentarioPostagem == StatusComentarioPostagem.Publicado)
            .OrderByDescending(c => c.DataRegistro)
            .ToListAsync();
        //depois implementar a paginação e a quantidade de comentarios
        return (postagem, comentarios, totalComentarios);
    }

    public async Task<List<Postagem>> ObterTodasPostagens()
    {
        var postagens = await context.Postagens.ToListAsync();
        
        return postagens;
    }

    public async Task<Postagem> Remover(Guid id)
    {
        if(id == Guid.Empty)
            throw new ArgumentNullException();
        
        var postagem = await context.Postagens.FirstOrDefaultAsync(x => x.Id == id);
        
        context.Postagens.Remove(postagem);
        await context.SaveChangesAsync();
        
        return new Postagem();
    }

    private void AtualizaCamposPreenchidosDaPostagem(Postagem postagem, Postagem existente, EntityEntry<Postagem> entry )
    {
        ValidarMudancasStatus(existente.StatusPostagem, postagem.StatusPostagem);
        
        if (postagem.DataAtualizacao.HasValue)
        {
            existente.DataAtualizacao = postagem.DataAtualizacao;
            entry.Property(p => p.DataAtualizacao).IsModified = true;
        }
        if (!string.IsNullOrWhiteSpace(postagem.Conteudo))
        {
            existente.Conteudo = postagem.Conteudo;
            entry.Property(p => p.Conteudo).IsModified = true;
        }
        if (postagem.Tags != null && postagem.Tags.Length > 0)
        {
            existente.Tags = postagem.Tags;
            entry.Property(p => p.Tags).IsModified = true;
        }
        
        
        //Campos fixos ou sempre atualizados
        existente.StatusPostagem = postagem.StatusPostagem;
        entry.Property(p => p.StatusPostagem).IsModified = true;

        existente.Anonimo = postagem.Anonimo;
        entry.Property(p => p.Anonimo).IsModified = true;

        existente.DataAtualizacao = DateTime.UtcNow;
        entry.Property(p => p.DataAtualizacao).IsModified = true;
        
    }
    
    private void ValidarMudancasStatus(StatusPostagem statusAtual, StatusPostagem novoStatus)
    {
        var transicoesPermitidas = new Dictionary<StatusPostagem, List<StatusPostagem>>
        {
            { StatusPostagem.Rascunho, new() { StatusPostagem.Publicado, StatusPostagem.Removido } },
            { StatusPostagem.Publicado, new() { StatusPostagem.Removido, StatusPostagem.Denuncia } },
            { StatusPostagem.Denuncia, new() { StatusPostagem.Removido, StatusPostagem.Publicado } },
            { StatusPostagem.Removido, new() { } } // Não pode sair de Removido
        };
        
        if (!transicoesPermitidas[statusAtual].Contains(novoStatus) && statusAtual != novoStatus)
        {
            throw new InvalidOperationException(
                $"Não é permitido mudar de {statusAtual} para {novoStatus}"
            );
        }
        
    }
    
    
}