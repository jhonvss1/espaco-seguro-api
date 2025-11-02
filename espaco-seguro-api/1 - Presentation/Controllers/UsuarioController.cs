using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Service;
using espaco_seguro_api._2___Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(UsuarioServiceApp serviceApp) : ControllerBase
{
    private UsuarioServiceApp _serviceApp = serviceApp;

    [HttpPost("criar")]
    public ActionResult<UsuarioResponse> Criar([FromBody] UsuarioRequestVm usuario)
    {
        try
        {
            var usuarioCriado = _serviceApp.CriarUsuario(usuario);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}