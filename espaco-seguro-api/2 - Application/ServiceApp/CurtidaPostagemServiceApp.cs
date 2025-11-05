using espaco_seguro_api._2___Application.Interfaces.Postagem;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class CurtidaPostagemServiceApp(ICurtidaPostagemService curtidaPostagemService) : ICurtidaPostagemServiceApp
{
    public async Task<int> Curtir(Guid postagemId, Guid usuarioId)
    {
        return await curtidaPostagemService.CurtirAsync(postagemId, usuarioId);
        
    }

    public async Task<int> Descurtir(Guid postagemId, Guid usuarioId)
    {
        return await curtidaPostagemService.DescurtirAsync(postagemId, usuarioId);
    }
}