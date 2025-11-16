using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._3___Domain.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController(ICardServiceApp cardServiceApp) : ControllerBase
    {
        #region Post

        [HttpPost("criar")]
        public async Task<ActionResult> Criar([FromBody] CardResquestVm cardResquestVm)
        {
            try
            {
                if (cardResquestVm is null)
                    return BadRequest("Payload invalido.");
                var cardCriado = await cardServiceApp.Criar(cardResquestVm, cardResquestVm.AutorId);
                return Created("", cardCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("enviar-revisao")]
        public async Task<IActionResult> EnviarRevisao([FromQuery] Guid cardId, Guid autorId)
        {
            await cardServiceApp.EnviarParaRevisao(cardId, autorId);
            return NoContent();
        }

        [HttpPost("iniciar-revisao")]
        public async Task<IActionResult> IniciarRevisao(Guid cardId, Guid autorId)
        {
            await cardServiceApp.IniciarRevisao(cardId, autorId);
            return NoContent();
        }

        [HttpPost("publicar")]
        public async Task<IActionResult> Publicar(Guid cardId, Guid autorId)
        {
            await cardServiceApp.Publicar(cardId, autorId);
            return NoContent();
        }

        [HttpPost("arquivar")]
        public async Task<IActionResult> Arquivar(Guid cardId, Guid autorId)
        {
            await cardServiceApp.Arquivar(cardId, autorId);
            return NoContent();
        }

        #endregion

        [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            try
            {
                var card = await cardServiceApp.ObterPorId(id);
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
                var cards = await cardServiceApp.ObterTodos();
                return Ok(cards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] CardResquestVm cardResquestVm, Guid cardId)
        {
            try
            {
                var response = await cardServiceApp.Atualizar(cardResquestVm, cardId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletar/{id:guid}")]
        public async Task<ActionResult> Deletar(Guid id, Guid autorId)
        {
            try
            {
                await cardServiceApp.Remover(id, autorId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
