using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace espaco_seguro_api._4___Data.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Usuario> Criar(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> Atualizar(Usuario usuario, Guid id)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> ObterPorId(Guid id)
    {
        var usuario = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        return usuario;
    }

    public async Task<List<Usuario>> ObterTodos()
    {
        var usuarios = await _context.Usuarios.AsNoTracking().ToListAsync();
        return usuarios;
    }

    public async Task<Usuario> Remover(Guid id)
    {
    var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    _context.Usuarios.Remove(usuario);
        return usuario;
    }
}