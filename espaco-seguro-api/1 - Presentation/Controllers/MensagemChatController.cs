using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MensagemChatController(IMensagemChatServiceApp mensagemChatServiceApp) : ControllerBase
{
    [HttpPost("enviar")]
    public async Task<ActionResult> Enviar([FromBody] MensagemChatRequestVm request)
    {
        try
        {
            if (request is null)
                return BadRequest("Payload inválido.");

            var mensagem = await mensagemChatServiceApp.Enviar(request);
            return Created(string.Empty, mensagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("sessao/{sessaoId:guid}")]
    public async Task<ActionResult> ObterPorSessao(Guid sessaoId)
    {
        try
        {
            var mensagens = await mensagemChatServiceApp.ObterPorSessao(sessaoId);
            return Ok(mensagens);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{mensagemId:guid}/marcar-lida")]
    public async Task<ActionResult> MarcarComoLida(Guid mensagemId)
    {
        try
        {
            var mensagem = await mensagemChatServiceApp.MarcarComoLida(mensagemId);
            return Ok(mensagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
