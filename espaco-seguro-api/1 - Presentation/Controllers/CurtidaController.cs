using espaco_seguro_api._3___Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CurtidaController(ICurtidaPostagemService curtidaPostagemService) : ControllerBase
{
    [HttpPost("{postagemId:guid}")]
    public async Task<ActionResult> Curtir(Guid postagemId, [FromQuery] Guid usuarioId)
    {
        var contagem = await curtidaPostagemService.CurtirAsync(postagemId, usuarioId);
        return Ok(new {liked = true, likesCount = contagem});
    }
    
    [HttpDelete("{postagemId:guid}")]
    public async Task<ActionResult> Descurtir(Guid postagemId, [FromQuery] Guid usuarioId)
    {
        var contagem = await curtidaPostagemService.DescurtirAsync(postagemId, usuarioId);
        return Ok(new {liked = false, likesCount = contagem});
    }
    
}