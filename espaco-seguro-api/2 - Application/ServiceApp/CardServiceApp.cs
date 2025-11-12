using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.ServiceApp
{
    public class CardServiceApp(ICardService cardService) : ICardServiceApp
    {
        public async Task<CardResponse> Criar(CardResquestVm cardResquestVm, Guid usuarioId)
        {
            var entidade = CardMapper.ParaEntidade(cardResquestVm);
            var criado = await cardService.Criar(entidade,  usuarioId);
            return CardMapper.ParaResponse(criado);
        }

        public Task EnviarParaRevisao(Guid cardId, Guid userId) =>
            cardService.EnviarParaRevisao(cardId, userId);


        public async Task IniciarRevisao(Guid cardId, Guid usuarioId) => 
            await cardService.IniciarRevisao(cardId, usuarioId);

        public async Task Publicar(Guid cardId, Guid usuarioId) =>
            await cardService.Publicar(cardId, usuarioId);

        public async Task Arquivar(Guid cardId, Guid usuarioId) => 
            await cardService.Arquivar(cardId, usuarioId);

        public async Task<CardResponse> Atualizar(CardResquestVm cardResquestVm, Guid id, Guid usuarioId)
        {
            var entidade = CardMapper.ParaEntidade(cardResquestVm);
            var atualizado = await cardService.Atualizar(entidade, id, usuarioId);
            return CardMapper.ParaResponse(atualizado);
        }

        public async Task<CardResponse> ObterPorId(Guid id)
        {
            var card = await cardService.ObterPorId(id);
            return CardMapper.ParaResponse(card);
        }

        public async Task<List<CardResponse>> ObterTodos()
        {
            var lista = await cardService.ObterTodos();
            return lista.Select(CardMapper.ParaResponse).ToList();
        }

        public Task Remover(Guid id, Guid userId) =>
            cardService.Remover(id, userId);
    }
}
