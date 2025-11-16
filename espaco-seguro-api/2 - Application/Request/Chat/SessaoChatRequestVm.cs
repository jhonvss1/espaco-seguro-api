using espaco_seguro_api._3___Domain.Chat;

namespace espaco_seguro_api._2___Application.Request.Chat;

public class SessaoChatRequestVm
{
    public Guid? UsuarioId { get; set; }
    public bool Anonima { get; set; }
    public TipoChat TipoChat { get; set; }
}
