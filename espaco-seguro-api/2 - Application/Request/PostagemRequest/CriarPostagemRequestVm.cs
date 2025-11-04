using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.Request;

public class CriarPostagemRequestVm
{
    public Guid AutorId { get; set; }
    public string Conteudo { get; set; }
    public bool Anonimo { get; set; }
    public string[]? Tags { get; set; }
}