namespace espaco_seguro_api._2___Application.Interfaces.Postagem;

public interface ICurtidaPostagemServiceApp
{
    public Task<int> Curtir(Guid postagemId, Guid usuarioId);
    public Task<int> Descurtir(Guid postagemId, Guid usuarioId);
}