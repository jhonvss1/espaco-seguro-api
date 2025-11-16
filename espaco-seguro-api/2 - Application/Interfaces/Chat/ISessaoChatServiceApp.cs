using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.Response.Chat;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;

public interface ISessaoChatServiceApp
{
    Task<SessaoChatResponse> Criar(SessaoChatRequestVm request);
    Task<SessaoChatResponse> ObterPorId(Guid sessaoId);
    Task<List<SessaoChatResponse>> ObterPorUsuario(Guid usuarioId);
    Task<SessaoChatResponse> Encerrar(Guid sessaoId);
}
