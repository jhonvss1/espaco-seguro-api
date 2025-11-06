using espaco_seguro_api._2___Application.Response.ComentarioPostagem;

namespace espaco_seguro_api._2___Application.Response;

public class PostagemCompletaResponse : PostagemResponse
{
    public List<ComentarioPostagemResponse> Comentarios { get; set; } = new();
}