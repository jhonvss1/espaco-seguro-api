namespace espaco_seguro_api._4___Data.Repositories;

public interface ICurtidaPostagemRepository
{
    public Task<int> CurtirAsync(Guid postagemId, Guid usuarioId);
    public Task<int> DescurtirAsync(Guid postagemId, Guid usuarioId);
}