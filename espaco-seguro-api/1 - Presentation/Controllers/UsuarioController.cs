using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ServiceApp;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._2___Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioServiceApp usuarioServiceApp) : ControllerBase
{
    [HttpPost("criar")]
    public async Task<ActionResult<UsuarioResponse>> Criar([FromBody] UsuarioRequestVm usuario)
    {
        try
        {
            await usuarioServiceApp.Criar(usuario);
            
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("obter/{id:guid}")]
    public async Task<ActionResult<UsuarioResponse>> ObterPorId(Guid id)
    {
        try
        {
            if (id.Equals(Guid.Empty))
                NoContent();
            
            return await usuarioServiceApp.ObterPorId(id);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("obter-todos")]
    public async Task<ActionResult<UsuarioResponse>> ObterTodos()
    {
        try
        {
            var usuarios = await usuarioServiceApp.ObterTodos();
            
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    [HttpPut("atualizar{id:guid}")]
    public async Task<ActionResult<UsuarioResponse>> Atualizar(Guid id, [FromBody] UsuarioRequestVm usuario)
    {
        try
        {
            await usuarioServiceApp.Atualizar(usuario, id);
            return Ok("Dados do usuário atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("remover/{id:guid}")]
    public async Task<ActionResult> Remover(Guid id)
    {
        try
        {
            await usuarioServiceApp.Remover(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}