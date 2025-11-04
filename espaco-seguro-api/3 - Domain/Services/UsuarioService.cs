using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._3___Domain.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    public async Task<Usuario> Criar(Usuario usuario)
    {
        if((bool)(!usuario.AceitouTermos)!) 
            throw new DomainValidationException("É necessário aceitar os termos.");
        
        
        
        return await usuarioRepository.Criar(usuario);
    }

    public async Task<Usuario> Atualizar(Usuario usuario, Guid id)
    {
        await usuarioRepository.Atualizar(usuario, id);
        var usuarioAtualizado = await usuarioRepository.ObterPorId(id);
        return usuarioAtualizado;
    }

    public async Task<List<Usuario>> ObterTodosUsuarios()
    {
        var usuarios = await usuarioRepository.ObterTodos();
        
        if (usuarios == null)
            throw new ArgumentNullException("Não foi possível retornar os usuários.");
        
        return usuarios;
    }

    public async Task<Usuario> ObterPorId(Guid id)
    {
        var usuario = await usuarioRepository.ObterPorId(id);
        return usuario;
    }

    public Task<Usuario> Deletar(Guid id)
    {
        if (id.Equals(Guid.Empty))
            throw new DomainValidationException("Id do usuário tem que ser informado corretamente.");
        
        return usuarioRepository.Deletar(id);
    }
}