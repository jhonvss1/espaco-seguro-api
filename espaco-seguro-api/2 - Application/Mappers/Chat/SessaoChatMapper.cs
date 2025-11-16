using System.Linq;
using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.Response.Chat;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._2___Application.Mappers.Chat;

public static class SessaoChatMapper
{
    public static SessaoChat ParaEntidade(SessaoChatRequestVm request)
    {
        return new SessaoChat
        {
            UsuarioId = request.UsuarioId,
            Anonima = request.Anonima,
            TipoChat = request.TipoChat
        };
    }

    public static SessaoChatResponse ParaResponse(SessaoChat sessao)
    {
        return new SessaoChatResponse
        {
            Id = sessao.Id,
            UsuarioId = sessao.UsuarioId,
            Anonima = sessao.Anonima,
            TipoChat = sessao.TipoChat,
            StatusChat = sessao.StatusChat,
            IniciadoEm = sessao.IniciadoEm,
            EncerradoEm = sessao.EncerradoEm,
            QuantidadeMensagens = sessao.Mensagens?.Count ?? 0
        };
    }

    public static List<SessaoChatResponse> ParaResponse(List<SessaoChat> sessoes)
    {
        return sessoes.Select(ParaResponse).ToList();
    }
}
