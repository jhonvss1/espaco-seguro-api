using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._2___Application.Mappers
{
    public class CardMapper
    {

        public static ConteudoCard ParaEntidade(CardResquestVm cardResquestVm)
        {
            var usuarioEntidadeDominio = new ConteudoCard
            {
                Titulo = cardResquestVm.Titulo,
                Resumo = cardResquestVm.Resumo,
                Corpo = cardResquestVm.Corpo,
                Tipo = cardResquestVm.Tipo,
                UrlMidia = cardResquestVm.UrlMidia,
            };
            return usuarioEntidadeDominio;
        }

        public static CardResponse ParaResponse(ConteudoCard card)
        {
            var cardVm = new CardResponse()
            {
                Id = card.Id,
                Titulo = card.Titulo,
                Resumo = card.Resumo,
                Corpo = card.Corpo,
                Tipo = card.Tipo,
                UrlMidia = card.UrlMidia,
                Status = card.Status,
                AutorId = card.AutorId,
                DataPublicacao = card.DataPublicacao,
                DataRegistro = card.DataRegistro,
                DataAtualizacao = card.DataAtualizacao,
                QuantidadeFontes = card.Fonte.Count,
                Verificacoes = card.Verificacao.Count
            };
            return cardVm;
        }
    }
}
