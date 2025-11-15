using System.Security.Claims;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._3___Domain.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace espaco_seguro_api._1___Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController(ICardServiceApp cardServiceApp) : ControllerBase
    {
        private Guid UsuarioId()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                     User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if (string.IsNullOrWhiteSpace(id))
                throw new UnauthorizedAccessException("Usuário não autenticado.");

            return Guid.Parse(id);
        }


        #region MyRegion
        
        [HttpPost("criar")]
        public async Task<ActionResult> Criar([FromBody] CardResquestVm cardResquestVm)
        {
            try
            {
                if (cardResquestVm is null)
                    return BadRequest("Payload inválido.");
                var cardCriado = await cardServiceApp.Criar(cardResquestVm, UsuarioId());
                return Created("", cardCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("{id:guid}/enviar-revisao")]
        public async Task<IActionResult> EnviarRevisao(Guid id)
        {
            await cardServiceApp.EnviarParaRevisao(id, UsuarioId());
            return NoContent();
        }
        
        
        [HttpPost("{id:guid}/iniciar-revisao")]
        public async Task<IActionResult> IniciarRevisao(Guid id)
        {
            await cardServiceApp.IniciarRevisao(id, UsuarioId());
            return NoContent();
        }
        
        [HttpPost("{id:guid}/publicar")]
        public async Task<IActionResult> Publicar(Guid id)
        {
            await cardServiceApp.Publicar(id, UsuarioId());
            return NoContent();
        }

        [HttpPost("{id:guid}/arquivar")]
        public async Task<IActionResult> Arquivar(Guid id)
        {
            await cardServiceApp.Arquivar(id, UsuarioId());
            return NoContent();
        }
        
        #endregion
        [Authorize(Policy = Permissoes.CardListar)]
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
        
        [Authorize(Policy = Permissoes.CardListar)]
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
        
        [Authorize(Policy = Permissoes.CardEditar)]
        [HttpPut("atualizar/{id:guid}")]
        public async Task<ActionResult> Atualizar(Guid id, [FromBody] CardResquestVm cardResquestVm)
        {
            try
            {
                var response = await cardServiceApp.Atualizar(cardResquestVm, id, UsuarioId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Authorize(Policy = Permissoes.CardDeletar)]
        [HttpDelete("deletar/{id:guid}")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            try
            {
                await cardServiceApp.Remover(id, UsuarioId());
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
