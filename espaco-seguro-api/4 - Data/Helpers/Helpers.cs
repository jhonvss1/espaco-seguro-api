using espaco_seguro_api._3___Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace espaco_seguro_api._4___Data.Helpers;

public class Helpers
{
     public void AtualizaCamposPreenchidosUsuario(Usuario usuario, Usuario existente, EntityEntry<Usuario> entry)
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