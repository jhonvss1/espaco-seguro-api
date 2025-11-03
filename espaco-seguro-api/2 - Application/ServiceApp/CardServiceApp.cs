using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.ServiceApp
{
    public class CardServiceApp(ICardService cardService) : ICardServiceApp
    {
        public async Task<CardResponse> Criar(CardResquestVm cardResquestVm)
        {
            try
            {
                var entidadeDominio = CardMapper.ParaEntidade(cardResquestVm);
                var criado = await cardService.Criar(entidadeDominio);
                var cardVm = CardMapper.ParaResponse(criado);
                return cardVm;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao criar card.");
            }
        }

        public async Task<CardResponse> ObterPorId(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                }
                var cardEntidadeDominio = await cardService.ObterPorId(id);
                var cardResponse = CardMapper.ParaResponse(cardEntidadeDominio);
                return cardResponse;
            }
            catch (Exception exception)
            {
                throw new ArgumentException("Erro ao buscar card.");
            }
        }

        public async Task<CardResponse> Atualizar(CardResquestVm cardVm, Guid id)
        {
            try
            {
                if( cardVm is null || id.Equals(Guid.Empty))
                    throw new ArgumentNullException(nameof(cardVm),
                        "O identificador informado é inválido ou não foi fornecido.");
                var cardEntidadeDominio = CardMapper.ParaEntidade(cardVm);
                var atualizado = await cardService.Atualizar(cardEntidadeDominio, id);
                var cardResponse = CardMapper.ParaResponse(atualizado);
                return cardResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao atualizar card.");
            }         
        }

        public Task<List<CardResponse>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<CardResponse> Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CardResponse> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CardResponse>> ObterTodos(CardResquestVm cardVm)
        {
            throw new NotImplementedException();
        }
    }
}
