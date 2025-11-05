using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request.ComentarioPostagem;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.ComentarioPostagem;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class ComentarioPostagemServiceApp(IComentarioPostagemService comentarioPostagemService) :IComentarioPostagemServiceApp
{
    public async Task<ComentarioPostagemResponse> Criar(ComentarioPostagemRequestVm comentarioPostagemVm)
    {
        var entidade = ComentarioPostagemMapper.ParaEntidade(comentarioPostagemVm);
        await comentarioPostagemService.Criar(entidade);
        var comentarioCriado = ComentarioPostagemMapper.ParaResponse(entidade);
        return comentarioCriado;
    }

    public async Task<List<ComentarioPostagemResponse>> ObterTodos()
    {
        var entidade = await comentarioPostagemService.ObterTodos();
        var response = ComentarioPostagemMapper.ParaReponseEmLista(entidade);
        return response;
    }

    public async Task<ComentarioPostagemResponse?> Deletar(Guid comentarioId)
    {
        await  comentarioPostagemService.Deletar(comentarioId);
        
        return new ComentarioPostagemResponse();
    }
}