using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.Response.Chat;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;

public interface IMensagemChatServiceApp
{
    Task<MensagemChatResponse> Enviar(MensagemChatRequestVm request);
    Task<List<MensagemChatResponse>> ObterPorSessao(Guid sessaoId);
    Task<MensagemChatResponse> MarcarComoLida(Guid mensagemId);
}
