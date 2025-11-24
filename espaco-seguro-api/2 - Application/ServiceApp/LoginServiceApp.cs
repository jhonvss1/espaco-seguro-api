using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using espaco_seguro_api._2___Application.Interfaces.Auth;
using espaco_seguro_api._2___Application.JwtSettings;
using espaco_seguro_api._2___Application.Request.Auth;
using espaco_seguro_api._2___Application.Response.LoginResponse;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;
using espaco_seguro_api._3___Domain.Security;

namespace espaco_seguro_api._2___Application.ServiceApp;

public sealed class LoginServiceApp : ILoginServiceApp
{
    
    private readonly ILoginService _loginDomain;
    private readonly IFabricadordeToken _tokenFactory;

    public LoginServiceApp(ILoginService loginDomain, IFabricadordeToken tokenFactory)
    {
        _loginDomain = loginDomain;
        _tokenFactory = tokenFactory;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequestVm req)
    {
        var resultado = await _loginDomain.AutenticarAsync(req.Email, req.Senha);
        if (!resultado.Ok) throw new UnauthorizedAccessException(resultado.Erro);

        var usuario = resultado.Usuario!;
        
        var token = _tokenFactory.GerarTokenAcesso(usuario);
        
        return new LoginResponse
        {
            TokenAcesso = token,
            UsuarioId =  usuario.Id,
            ExpiracaoTokenAcesso   = _tokenFactory.ObterExpiracaoTokenAcesso(),
            Email       = usuario.Email,
            Nome        = usuario.Nome,
            Funcao      = usuario.Funcao.ToString()
        };
    }
}