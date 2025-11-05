using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._3___Domain.Services.Postagem.ComentarioPostagem;

public class ComentarioPostagemService(IComentarioPostagemRepository comentarioPostagemRepository) : IComentarioPostagemService
{
    public async Task<Entities.ComentarioPostagem> Criar(Entities.ComentarioPostagem comentarioPostagem)
    {
        var comentario = await comentarioPostagemRepository.Criar(comentarioPostagem);
        return comentario;
    }

    public async Task<List<Entities.ComentarioPostagem>> ObterTodos()
    {
        return await comentarioPostagemRepository.ObterTodos();
    }

    public async Task<Entities.ComentarioPostagem?> Deletar(Guid comentarioId)
    {
        return await comentarioPostagemRepository.Deletar(comentarioId);
    }
}