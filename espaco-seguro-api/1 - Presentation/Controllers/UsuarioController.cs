using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ServiceApp;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._2___Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(IUsuarioServiceApp serviceApp) : ControllerBase
{
    private IUsuarioServiceApp serviceApp = serviceApp;

    [HttpPost("criar")]
    public async Task<ActionResult<UsuarioResponse>> Criar([FromBody] UsuarioRequestVm usuario)
    {
        try
        {
            if (usuario is null)
                NoContent();
            
            var usuarioCriado = await serviceApp.Criar(usuario);
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
            
            return await serviceApp.ObterPorId(id);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizar")]
    public async Task<ActionResult<UsuarioResponse>> Atualizar(Guid id, [FromBody] UsuarioRequestVm usuario)
    {
        try
        {
            await serviceApp.Atualizar(usuario, id);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
}