using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController(ICardServiceApp cardServiceApp) : ControllerBase
    {
        private ICardServiceApp _cardServiceApp = cardServiceApp;

        [HttpPost("criar")]
        public async Task<ActionResult> Criar([FromBody] CardResquestVm cardResquestVm)
        {
            try
            {
                if (cardResquestVm is null)
                    return NoContent();
                var cardCriado = await _cardServiceApp.Criar(cardResquestVm);
                return Created("", cardCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return NoContent();
                var card = await _cardServiceApp.ObterPorId(id);
                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obter-todos")]
        public async Task<ActionResult> ObterTodosCards()
        {
            try
            {
                var cards = await _cardServiceApp.ObterTodos();
                return Ok(cards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("atualizar/{id:guid}")]
        public async Task<ActionResult> Atualizar(Guid id, [FromBody] CardResquestVm cardResquestVm)
        {
            try
            {
                await _cardServiceApp.Atualizar(cardResquestVm, id);
                return Created("", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("deletar/{id:guid}")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            try
            {
                await _cardServiceApp.Remover(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
