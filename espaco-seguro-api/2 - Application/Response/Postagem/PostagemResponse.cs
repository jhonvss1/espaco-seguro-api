using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.Response;

public class PostagemResponse
{
    public Guid Id { get; set; }
    public Guid AutorId { get; set; }
    public string Conteudo { get; set; }
    public bool Anonimo { get; set; }
    public StatusPostagem  StatusPostagem { get; set; }
    public string[]? Tags { get; set; }
    public int ContagemCurtidas { get; set; }   
    public int ContagemComentarios { get; set; }
    
    public DateTime DataPublicacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    
}