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
    var existente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    if (existente is null)
        throw new KeyNotFoundException("Usuário não encontrado para atualização.");
    
    var entry = _context.Entry(existente);

    AtualizaCamposPreenchidos(usuario, existente, entry);

    await _context.SaveChangesAsync();
    return existente;
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
    await _context.SaveChangesAsync();
        return usuario;
    }

    private void AtualizaCamposPreenchidos(Usuario usuario, Usuario existente, EntityEntry<Usuario> entry)
    {
        if (!string.IsNullOrWhiteSpace(usuario.Email))
        {
            existente.Email = usuario.Email;
            entry.Property(p => p.Email).IsModified = true;
        }

        if (!string.IsNullOrWhiteSpace(usuario.Nome))
        {
            existente.Nome = usuario.Nome;
            entry.Property(p => p.Nome).IsModified = true;
        }

        if (usuario.DataNascimento.HasValue)
        {
            existente.DataNascimento = usuario.DataNascimento;
            entry.Property(p => p.DataNascimento).IsModified = true;
        }

        if (!string.IsNullOrWhiteSpace(usuario.Telefone))
        {
            existente.Telefone = usuario.Telefone;
            entry.Property(p => p.Telefone).IsModified = true;
        }

        if (!string.IsNullOrWhiteSpace(usuario.Cpf))
        {
            existente.Cpf = usuario.Cpf;
            entry.Property(p => p.Cpf).IsModified = true;
        }

        if (!string.IsNullOrWhiteSpace(usuario.Foto))
        {
            existente.Foto = usuario.Foto;
            entry.Property(p => p.Foto).IsModified = true;
        }

        if (!string.IsNullOrWhiteSpace(usuario.SenhaHash))
        {
            existente.SenhaHash = usuario.SenhaHash;
            entry.Property(p => p.SenhaHash).IsModified = true;
        }

        // Campos fixos ou sempre atualizados
        existente.AceitouTermos = usuario.AceitouTermos;
        entry.Property(p => p.AceitouTermos).IsModified = true;

        existente.Funcao = usuario.Funcao;
        entry.Property(p => p.Funcao).IsModified = true;

        existente.StatusUsuario = usuario.StatusUsuario;
        entry.Property(p => p.StatusUsuario).IsModified = true;

        existente.DataAceiteTermos = usuario.DataAceiteTermos;
        entry.Property(p => p.DataAceiteTermos).IsModified = true;

        existente.UltimoAcesso = usuario.UltimoAcesso;
        entry.Property(p => p.UltimoAcesso).IsModified = true;

        existente.DataAtualizacao = DateTime.UtcNow;
        entry.Property(p => p.DataAtualizacao).IsModified = true;
    }
    
}