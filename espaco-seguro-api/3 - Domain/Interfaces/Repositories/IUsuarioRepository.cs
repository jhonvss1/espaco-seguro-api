using espaco_seguro_api._3___Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace espaco_seguro_api._3___Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> Criar(Usuario usuario);
    Task<Usuario> Atualizar(Usuario usuario, Guid id);
    Task<Usuario> ObterPorId(Guid id);
    Task<Usuario> ObterPorEmail(string email);
    Task<List<Usuario>> ObterTodos();
    Task<Usuario> Deletar(Guid id);
}