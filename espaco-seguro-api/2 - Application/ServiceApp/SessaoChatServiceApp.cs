using espaco_seguro_api._2___Application.Mappers.Chat;
using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.Response.Chat;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;
using espaco_seguro_api._3___Domain.Interfaces.Services.Chat;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class SessaoChatServiceApp(ISessaoChatService sessaoChatService) : ISessaoChatServiceApp
{
    public async Task<SessaoChatResponse> Criar(SessaoChatRequestVm request)
    {
        var entidade = SessaoChatMapper.ParaEntidade(request);
        var sessao = await sessaoChatService.Criar(entidade);
        return SessaoChatMapper.ParaResponse(sessao);
    }

    public async Task<SessaoChatResponse> ObterPorId(Guid sessaoId)
    {
        var sessao = await sessaoChatService.ObterPorId(sessaoId);
        return SessaoChatMapper.ParaResponse(sessao);
    }

    public async Task<List<SessaoChatResponse>> ObterPorUsuario(Guid usuarioId)
    {
        var sessoes = await sessaoChatService.ObterPorUsuario(usuarioId);
        return SessaoChatMapper.ParaResponse(sessoes);
    }

    public async Task<SessaoChatResponse> Encerrar(Guid sessaoId)
    {
        var encerrada = await sessaoChatService.Encerrar(sessaoId);
        return SessaoChatMapper.ParaResponse(encerrada);
    }
}
