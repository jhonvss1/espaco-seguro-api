using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.Response;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using Microsoft.AspNetCore.Mvc;

namespace espaco_seguro_api._1___Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PostagemController(IPostagemServiceApp postagemServiceApp) : ControllerBase
{
    [HttpPost("criar")]
    public async Task<ActionResult<CriarPostagemRequestVm>> Criar(CriarPostagemRequestVm criarPostagem)
    {
        try
        {
            await postagemServiceApp.Criar(criarPostagem);
            return Ok(criarPostagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
    [HttpGet("obter/{id:guid}")]
    public async Task<ActionResult<PostagemReponse>> ObterPorId(Guid id)
    {
        try
        {
            var postagem = await postagemServiceApp.ObterPorId(id);
            return Ok(postagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("obter-todas")]
    public async Task <ActionResult<List<PostagemReponse>>> ObterTodasPostagens()
    {
        try
        {
            var postagem = await postagemServiceApp.ObterTodas();
            return Ok(postagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizar/{id:guid}")]
    public async Task<ActionResult<PostagemReponse>> Atualizar([FromBody] CriarPostagemRequestVm postagem, Guid id)
    {
        try
        {
            var postagemAtualizada = await postagemServiceApp.Atualizar(postagem, id);
            return Ok(postagemAtualizada);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);   
        }
    }
    
    [HttpDelete("remover/{id:guid}")]
    public async Task<ActionResult<PostagemReponse>> Remover(Guid id)
    {
        try
        {
            var postagem = await postagemServiceApp.ObterPorId(id);
            return Ok(postagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}