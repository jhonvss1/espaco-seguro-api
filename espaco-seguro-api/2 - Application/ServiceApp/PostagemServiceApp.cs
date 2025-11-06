using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class PostagemServiceApp(IPostagemService postagemService) : IPostagemServiceApp
{
    
    
    public async Task<PostagemResponse> Criar(CriarPostagemRequestVm criarPostagemRequestVm)
    {
        var postagemEntidade = PostagemMapper.ParaEntidade(criarPostagemRequestVm);
        
        var postagemCriada = await postagemService.Criar(postagemEntidade);
        
        var postagemVm = PostagemMapper.ParaReponse(postagemCriada);
        
        return postagemVm;
        
    }

    public async Task<PostagemResponse> ObterPorId(Guid id)
    {
        var postagemEntidade = await postagemService.ObterPorId(id);
        
        var postagemVm  = PostagemMapper.ParaReponse(postagemEntidade);
        
        return postagemVm;
    }
    public async Task<PostagemCompletaResponse> ObterPostagemComComentarios(Guid id)
    {
        var (postagens, comentarios, total) = await postagemService.ObterPostagemComComentarios(id);
        return PostagemMapper.ParaPostagemDetalhadaResponse(postagens, comentarios, total);
    }
    public async Task<PostagemResponse> Atualizar(CriarPostagemRequestVm criarPostagemVm, Guid id)
    {
        var postagem = PostagemMapper.ParaEntidade(criarPostagemVm);
        
        await postagemService.Atualizar(postagem, id);
        
        var postagemVm =  PostagemMapper.ParaReponse(postagem);
        
        return postagemVm;
    }

    public async Task<List<PostagemResponse>> ObterTodas()
    {
        var postagens = await postagemService.ObterTodasPostagens();
        
        var postagensVm =  PostagemMapper.ParaReponseEmLista(postagens);
        
        return postagensVm;
    }
    
    public async Task<PostagemResponse> Remover(Guid id)
    {
         await postagemService.Deletar(id);
         return new PostagemResponse();
    }
}