namespace espaco_seguro_api._2___Application.Request.ComentarioPostagem;

public class ComentarioPostagemRequestVm
{
    public Guid AutorId { get; set; }
    public Guid PostagemId { get; set; }
    public string Conteudo { get; set; }
    public bool Anonimo { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    
}