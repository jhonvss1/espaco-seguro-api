using espaco_seguro_api._2___Application.Mappers.Chat;
using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.Response.Chat;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;
using espaco_seguro_api._3___Domain.Interfaces.Services.Chat;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class MensagemChatServiceApp(IMensagemChatService mensagemChatService) : IMensagemChatServiceApp
{
    public async Task<MensagemChatResponse> Enviar(MensagemChatRequestVm request)
    {
        var entidade = MensagemChatMapper.ParaEntidade(request);
        var mensagem = await mensagemChatService.Enviar(entidade);
        return MensagemChatMapper.ParaResponse(mensagem);
    }

    public async Task<List<MensagemChatResponse>> ObterPorSessao(Guid sessaoId)
    {
        var mensagens = await mensagemChatService.ObterPorSessao(sessaoId);
        return MensagemChatMapper.ParaResponse(mensagens);
    }

    public async Task<MensagemChatResponse> MarcarComoLida(Guid mensagemId)
    {
        var mensagem = await mensagemChatService.MarcarComoLida(mensagemId);
        return MensagemChatMapper.ParaResponse(mensagem);
    }
}
