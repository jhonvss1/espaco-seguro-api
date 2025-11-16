using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services.Chat;

public interface IMensagemChatService
{
    Task<MensagemChat> Enviar(MensagemChat mensagem);
    Task<List<MensagemChat>> ObterPorSessao(Guid sessaoId);
    Task<MensagemChat> MarcarComoLida(Guid mensagemId);
}
