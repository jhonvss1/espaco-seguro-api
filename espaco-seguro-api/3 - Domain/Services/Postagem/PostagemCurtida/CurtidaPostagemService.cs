using espaco_seguro_api._3___Domain.Interfaces.Services;
using espaco_seguro_api._4___Data;
using espaco_seguro_api._4___Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace espaco_seguro_api._3___Domain.Services;

public class CurtidaPostagemService(ICurtidaPostagemRepository curtidaPostagemRepository) : ICurtidaPostagemService
{
    public async Task<int> CurtirAsync(Guid postagemId, Guid usuarioId)
    {
        return await curtidaPostagemRepository.CurtirAsync(postagemId, usuarioId);
    }

    public async Task<int> DescurtirAsync(Guid postagemId, Guid usuarioId)
    {
        return await curtidaPostagemRepository.DescurtirAsync(postagemId, usuarioId);
    }
    
}