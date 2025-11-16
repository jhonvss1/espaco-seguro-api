using espaco_seguro_api._3___Domain.Chat;

namespace espaco_seguro_api._2___Application.Request.Chat;

public class MensagemChatRequestVm
{
    public Guid SessaoId { get; set; }
    public Guid? RemetenteId { get; set; }
    public string Conteudo { get; set; }
    public TipoMensagem TipoMensagem { get; set; }
}
