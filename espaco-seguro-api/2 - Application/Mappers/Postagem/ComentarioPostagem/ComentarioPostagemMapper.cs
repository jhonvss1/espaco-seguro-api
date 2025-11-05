using espaco_seguro_api._2___Application.Request.ComentarioPostagem;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;
using  espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._2___Application.Mappers;

public class ComentarioPostagemMapper
{
    public static ComentarioPostagem ParaEntidade(ComentarioPostagemRequestVm comentarioPostagemRequestVm)
    {
        var entidadeDominio = new ComentarioPostagem
        {
            AutorId = comentarioPostagemRequestVm.AutorId,
            PostagemId = comentarioPostagemRequestVm.PostagemId,
            Conteudo = comentarioPostagemRequestVm.Conteudo,
            Anonimo = comentarioPostagemRequestVm.Anonimo,
            DataRegistro = comentarioPostagemRequestVm.DataRegistro,
        };
        return entidadeDominio;
    }
    
    public static ComentarioPostagemResponse ParaResponse(ComentarioPostagem comentarioPostagem)
    {
        var response = new ComentarioPostagemResponse
        {
            AutorId = comentarioPostagem.AutorId,
            Id = comentarioPostagem.PostagemId,
            Conteudo = comentarioPostagem.Conteudo,
            Anonimo = comentarioPostagem.Anonimo,
            DataPublicacao = comentarioPostagem.DataRegistro,
            StatusComentarioPostagem = comentarioPostagem.StatusComentarioPostagem,
            ContagemCurtidas = comentarioPostagem.ContagemCurtidas,
        };
        return response;
    }

    public static List<ComentarioPostagemResponse> ParaReponseEmLista(List<ComentarioPostagem> comentarios)
    {
        return comentarios.Select(comentarios => new ComentarioPostagemResponse
        {
            AutorId = comentarios.AutorId,
            Id = comentarios.PostagemId,
            Conteudo = comentarios.Conteudo,
            Anonimo = comentarios.Anonimo,
            DataPublicacao = comentarios.DataRegistro,
            StatusComentarioPostagem = comentarios.StatusComentarioPostagem,
            ContagemCurtidas = comentarios.ContagemCurtidas,
        }).ToList();
    }
    
}