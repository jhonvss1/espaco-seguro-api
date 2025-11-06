using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._2___Application.Mappers;

public class PostagemMapper
{
    
    public static Postagem ParaEntidade(CriarPostagemRequestVm criarPostagem)
    {
        var postagemEntidade = new Postagem
        {
            AutorId = criarPostagem.AutorId,
            Anonimo = criarPostagem.Anonimo,
            Conteudo = criarPostagem.Conteudo,
            Tags = criarPostagem.Tags ?? Array.Empty<string>(),
        };
        return  postagemEntidade;
    }
    
    public static PostagemResponse ParaReponse(Postagem postagem)
    {
        var postagemVm = new PostagemResponse
        {
            Id =  postagem.Id,
            AutorId = postagem.AutorId,
            Anonimo = postagem.Anonimo,
            ContagemComentarios = postagem.ContagemComentarios,
            ContagemCurtidas = postagem.ContagemCurtidas,
            Conteudo = postagem.Conteudo,
            StatusPostagem = postagem.StatusPostagem,   
            Tags = postagem.Tags,
            DataAtualizacao = postagem.DataAtualizacao,
            DataPublicacao = postagem.DataPublicacao
        };
        return  postagemVm;
    }

    public static List<PostagemResponse> ParaReponseEmLista(List<Postagem> postagens)
    {
        return postagens.Select(postagens => new PostagemResponse
        {
            Id =  postagens.Id,
            AutorId = postagens.AutorId,
            Anonimo = postagens.Anonimo,
            ContagemComentarios = postagens.ContagemComentarios,
            ContagemCurtidas = postagens.ContagemCurtidas,
            Conteudo = postagens.Conteudo,
            StatusPostagem = postagens.StatusPostagem,   
            Tags = postagens.Tags,
            DataAtualizacao = postagens.DataAtualizacao,
            DataPublicacao = postagens.DataPublicacao
        }).ToList();
    }


    public static ComentarioPostagemResponse ParaComentarioReponse(ComentarioPostagem comentarioPostagem)
    {
        return new ComentarioPostagemResponse
        {
            Id = comentarioPostagem.Id,
            AutorId = comentarioPostagem.AutorId,
            Conteudo = comentarioPostagem.Conteudo,
            Anonimo = comentarioPostagem.Anonimo,
            StatusComentarioPostagem = comentarioPostagem.StatusComentarioPostagem,
            ContagemCurtidas = comentarioPostagem.ContagemCurtidas,
            DataPublicacao = comentarioPostagem.DataRegistro
        };
    }
    
    public static PostagemCompletaResponse ParaPostagemDetalhadaResponse(Postagem postagem, IReadOnlyList<ComentarioPostagem> comentarios, int totalComentarios)
    {
        return new PostagemCompletaResponse
        {
            Id = postagem.Id,
            AutorId = postagem.AutorId,
            Conteudo = postagem.Conteudo,
            Tags = postagem.Tags,
            Anonimo = postagem.Anonimo,
            StatusPostagem = postagem.StatusPostagem,
            ContagemCurtidas = postagem.ContagemCurtidas,
            DataAtualizacao = postagem.DataAtualizacao,
            DataPublicacao = postagem.DataPublicacao,
            Comentarios = comentarios.Select(ParaComentarioReponse).ToList()
        };
    }
    
}