using espaco_seguro_api._2___Application.Request.ComentarioPostagem;
using espaco_seguro_api._2___Application.Response.ComentarioPostagem;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.ComentarioPostagem;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ComentarioController(IComentarioPostagemServiceApp comentarioPostagemServiceApp) : ControllerBase
{
    [HttpPost("comentar")]
    public async Task<ActionResult<ComentarioPostagemResponse>> Criar(ComentarioPostagemRequestVm comentarioPostagem)
    {
        try
        {
            var comentario = await comentarioPostagemServiceApp.Criar(comentarioPostagem);
            return Ok(comentario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
    [HttpGet("comentarios")]
    public async Task<ActionResult<ComentarioPostagemResponse>> ObterTodos()
    {
        try
        {
            var comentarios = await comentarioPostagemServiceApp.ObterTodos();
            return Ok(comentarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ComentarioPostagemResponse>> Deletar(Guid id)
    {
        try
        {
             await comentarioPostagemServiceApp.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}