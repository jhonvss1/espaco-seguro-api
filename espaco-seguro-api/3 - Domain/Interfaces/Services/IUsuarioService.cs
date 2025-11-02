using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Interfaces.Services;

public interface IUsuarioService
{
    Task<Usuario> Criar(Usuario usuario);
    Task<Usuario> Atualizar(Usuario usuario, Guid id);
    Task<List<Usuario>> ObterTodosUsuarios();
    Task<Usuario> ObterPorId(Guid id);
    Task<Usuario> Deletar(Guid id);
}