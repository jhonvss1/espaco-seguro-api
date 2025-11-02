using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Interfaces;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._3___Domain.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository): IUsuarioService
{
    
    public async Task<Usuario> Criar(Usuario usuario)
    {
        try
        {
            if (usuario == null)
                throw new ArgumentNullException();
            
            return await usuarioRepository.Criar(usuario);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Não foi possível criar um novo usuário", ex);
        }
    }

    public Task<Usuario> Atualizar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<List<UsuarioResponse>> ObterTodosUsuarios()
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioResponse> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}