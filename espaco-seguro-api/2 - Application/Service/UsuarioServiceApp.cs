using espaco_seguro_api._2___Application.Mappers;
using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain.Interfaces.Services;

namespace espaco_seguro_api._2___Application.Service;

public class UsuarioServiceApp(IUsuarioService usuarioService)
{
    
    public UsuarioResponse CriarUsuario(UsuarioRequestVm usuarioRequestVm)
    {
        var entidadeDominio = UsuarioMapper.ParaEntidade(usuarioRequestVm);
        
        usuarioService.Criar(entidadeDominio);
        
        var userVm = UsuarioMapper.ParaResponse(entidadeDominio);
        
        return userVm;
    }
}