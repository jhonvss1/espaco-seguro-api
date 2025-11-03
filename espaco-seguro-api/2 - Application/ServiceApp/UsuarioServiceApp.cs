using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class UsuarioServiceApp(IUsuarioService usuarioService) : IUsuarioServiceApp
{
    
    public async Task<UsuarioResponse> Criar(UsuarioRequestVm usuarioRequestVm)
    {
        try
        {
            var entidadeDominio = UsuarioMapper.ParaEntidade(usuarioRequestVm);

            var criado = await usuarioService.Criar(entidadeDominio);

            var userVm = UsuarioMapper.ParaResponse(criado);

            return userVm;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Erro ao criar usuário.");
        }
    }

    public async Task<UsuarioResponse> ObterPorId(Guid id)
    {
        try
        {
            if (id != Guid.Empty)
            {
                
            }
            
            var usuarioEntidadeDominio = await usuarioService.ObterPorId(id);

            var usuarioResponse = UsuarioMapper.ParaResponse(usuarioEntidadeDominio);

            return usuarioResponse;
        }
        catch (Exception exception)
        {
            throw new ArgumentException("Erro ao buscar usuário.");
        }

    }

    public async Task<UsuarioResponse> Atualizar(UsuarioRequestVm usuarioVm, Guid id)
    {
        try
        {
            if (usuarioVm is null || id.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(usuarioVm),
                    "O identificador informado é inválido ou não foi fornecido.");

            var usuarioEntidadeDominio = UsuarioMapper.ParaEntidade(usuarioVm);

            var usuarioAtualizado = await usuarioService.Atualizar(usuarioEntidadeDominio, id);

            var usuarioResponse = UsuarioMapper.ParaResponse(usuarioAtualizado);

            return usuarioResponse;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Erro ao atualizar card.");
        }
    }

    public Task<UsuarioResponse> ObterTodos(UsuarioRequestVm usuarioVm)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioResponse> Remover(Guid id)
    {
        throw new NotImplementedException();
    }
}