using espaco_seguro_api._2___Application.Request.Chat;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessaoChatController(ISessaoChatServiceApp sessaoChatServiceApp) : ControllerBase
{
    [HttpPost("criar")]
    public async Task<ActionResult> Criar([FromBody] SessaoChatRequestVm request)
    {
        try
        {
            if (request is null)
                return BadRequest("Payload inválido.");

            var sessao = await sessaoChatServiceApp.Criar(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = sessao.Id }, sessao);
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
            var sessao = await sessaoChatServiceApp.ObterPorId(id);
            return Ok(sessao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("usuario/{usuarioId:guid}")]
    public async Task<ActionResult> ObterPorUsuario(Guid usuarioId)
    {
        try
        {
            var sessoes = await sessaoChatServiceApp.ObterPorUsuario(usuarioId);
            return Ok(sessoes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id:guid}/encerrar")]
    public async Task<ActionResult> Encerrar(Guid id)
    {
        try
        {
            var sessao = await sessaoChatServiceApp.Encerrar(id);
            return Ok(sessao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
