namespace espaco_seguro_api._3___Domain.Interfaces.Services;

public interface ICurtidaPostagemService
{
    Task<int> CurtirAsync(Guid postagemId, Guid usuarioId);
    Task<int> DescurtirAsync(Guid postagemId, Guid usuarioId);
}