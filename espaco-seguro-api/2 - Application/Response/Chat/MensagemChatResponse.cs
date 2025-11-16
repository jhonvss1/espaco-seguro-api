using espaco_seguro_api._3___Domain.Chat;

namespace espaco_seguro_api._2___Application.Response.Chat;

public class MensagemChatResponse
{
    public Guid Id { get; set; }
    public Guid SessaoId { get; set; }
    public Guid? RemetenteId { get; set; }
    public string Conteudo { get; set; }
    public TipoMensagem TipoMensagem { get; set; }
    public bool Lida { get; set; }
    public DateTime? DataLida { get; set; }
    public DateTime DataEnvio { get; set; }
}
