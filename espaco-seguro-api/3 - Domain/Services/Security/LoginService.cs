using espaco_seguro_api._3___Domain.Entities.Login;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;
using espaco_seguro_api._3___Domain.Security;
using Microsoft.AspNetCore.Identity;

namespace espaco_seguro_api._3___Domain.Services.Security;

public class LoginService(IUsuarioRepository usuarioRepository, IPasswordHasher hasher) : ILoginService
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
    private readonly IPasswordHasher _hasher = hasher;
    public async Task<ResultadoAutenticacao> AutenticarAsync(string email, string senha)
    {
        var usuario = await _usuarioRepository.ObterPorEmail(email);
        
        if (usuario is null) 
            return ResultadoAutenticacao.CredenciaisInvalidas();
        
        if (!usuario.VerificarSenha(senha, _hasher))
            return ResultadoAutenticacao.CredenciaisInvalidas();
        
        return ResultadoAutenticacao.Sucesso(usuario);
    }
}