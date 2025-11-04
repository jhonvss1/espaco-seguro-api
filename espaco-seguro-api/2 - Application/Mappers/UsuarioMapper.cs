using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace espaco_seguro_api._2___Application.Mappers;

public class UsuarioMapper
{
    public static Usuario ParaEntidade(UsuarioRequestVm usuarioRequestVm)
    {
        var usuarioEntidadeDominio = new Usuario
        {
            Id = Guid.NewGuid(),
            Email = usuarioRequestVm.Email,
            Nome = usuarioRequestVm.Nome,
            DataNascimento = usuarioRequestVm.DataNascimento,
            Telefone = usuarioRequestVm.Telefone,
            Cpf = usuarioRequestVm.Cpf,
            AceitouTermos = usuarioRequestVm.AceitouTermos,
            Funcao = usuarioRequestVm.Funcao,
            Foto =  usuarioRequestVm.Foto,
            StatusUsuario = StatusUsuario.Pendente,
            DataAceiteTermos = DateTime.UtcNow,
            DataRegistro = DateTime.UtcNow,
            DataAtualizacao = DateTime.UtcNow,
            UltimoAcesso = null,
            SenhaHash = usuarioRequestVm.Senha

        };
        
        return usuarioEntidadeDominio;
    }

    public static UsuarioResponse ParaResponse(Usuario usuario)
    {
        var usuarioVm = new UsuarioResponse()
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            DataNascimento = usuario.DataNascimento,
            Telefone = usuario.Telefone,
            Foto = usuario.Foto,
            Funcao = usuario.Funcao,
            StatusUsuario = usuario.StatusUsuario,
            DataAceiteTermos = usuario.DataAceiteTermos,
            DataAtualizacao = usuario.DataAtualizacao,
            DataRegistro = usuario.DataRegistro,
            UltimoAcesso = usuario.UltimoAcesso,
            QuantidadeCartoes = usuario.Cartoes.Count,
            QuantidadePostagens = usuario.Cartoes.Count,
            QuantidadeSessoes = usuario.Cartoes.Count,
        };
        return usuarioVm;
    }
    public static List<UsuarioResponse> ParaResponseEmLista(List<Usuario> usuariosVm)
    {
        return usuariosVm.Select(usuario => new UsuarioResponse
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            DataNascimento = usuario.DataNascimento,
            Telefone = usuario.Telefone,
            Foto = usuario.Foto,
            Funcao = usuario.Funcao,
            StatusUsuario = usuario.StatusUsuario,
            DataAceiteTermos = usuario.DataAceiteTermos,
            DataAtualizacao = usuario.DataAtualizacao,
            DataRegistro = usuario.DataRegistro,
            QuantidadeCartoes = usuario.Cartoes?.Count ?? 0,
            QuantidadePostagens = usuario.Postagens?.Count ?? 0,
            QuantidadeSessoes = usuario.Sessoes?.Count ?? 0
        }).ToList();
    }
    
}