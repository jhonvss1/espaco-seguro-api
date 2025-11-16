using System.Linq;
using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.Response.Chat;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._2___Application.Mappers.Chat;

public static class MensagemChatMapper
{
    public static MensagemChat ParaEntidade(MensagemChatRequestVm request)
    {
        return new MensagemChat
        {
            SessaoId = request.SessaoId,
            RemetenteId = request.RemetenteId,
            Conteudo = request.Conteudo,
            TipoMensagem = request.TipoMensagem
        };
    }

    public static MensagemChatResponse ParaResponse(MensagemChat mensagem)
    {
        return new MensagemChatResponse
        {
            Id = mensagem.Id,
            SessaoId = mensagem.SessaoId,
            RemetenteId = mensagem.RemetenteId,
            Conteudo = mensagem.Conteudo,
            TipoMensagem = mensagem.TipoMensagem,
            Lida = mensagem.Lida,
            DataLida = mensagem.DataLida,
            DataEnvio = mensagem.DataEnvio
        };
    }

    public static List<MensagemChatResponse> ParaResponse(List<MensagemChat> mensagens)
    {
        return mensagens.Select(ParaResponse).ToList();
    }
}
