using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.Response.ComentarioPostagem;

public class ComentarioPostagemResponse
{
    public Guid Id { get; set; }
    public Guid AutorId { get; set; }
    public string Conteudo { get; set; }
    public bool Anonimo { get; set; }
    public StatusComentarioPostagem StatusComentarioPostagem { get; set; }
    public DateTime DataPublicacao { get; set; }
    public int ContagemCurtidas { get; set; }
}