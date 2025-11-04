using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
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
    
    public static PostagemReponse ParaReponse(Postagem postagem)
    {
        var postagemVm = new PostagemReponse
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

    public static List<PostagemReponse> ParaReponseEmLista(List<Postagem> postagens)
    {
        return postagens.Select(postagens => new PostagemReponse
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
    
}