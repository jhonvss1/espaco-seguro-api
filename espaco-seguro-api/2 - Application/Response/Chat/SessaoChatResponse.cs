using espaco_seguro_api._3___Domain.Chat;

namespace espaco_seguro_api._2___Application.Response.Chat;

public class SessaoChatResponse
{
    public Guid Id { get; set; }
    public Guid? UsuarioId { get; set; }
    public bool Anonima { get; set; }
    public StatusChat StatusChat { get; set; }
    public TipoChat TipoChat { get; set; }
    public DateTime IniciadoEm { get; set; }
    public DateTime? EncerradoEm { get; set; }
    public int QuantidadeMensagens { get; set; }
}
