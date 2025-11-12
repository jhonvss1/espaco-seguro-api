using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using espaco_seguro_api._2___Application.JwtSettings;
using espaco_seguro_api._3___Domain;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Security;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace espaco_seguro_api._5___Infra.Auth;

public class FabricadorDeToken : IFabricadordeToken
{
    private readonly JwtSettings _jwtSettings;
    private readonly SigningCredentials _credentials;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    public FabricadorDeToken(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        _credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public string GerarTokenAcesso(Usuario usuario, IEnumerable<Claim>? claimsExtras = null)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString(), ClaimValueTypes.Integer64),
            new(JwtRegisteredClaimNames.Email, usuario.Email),
            new(JwtRegisteredClaimNames.UniqueName, usuario.Nome),
            new(ClaimTypes.Role, usuario.Funcao.ToString() ?? throw new InvalidOperationException())
        };

        var permissoes = ObterPermissoesPorFuncao(usuario.Funcao);
        claims.AddRange(permissoes.Select(p => new Claim("permissoes", p)));

        if (claimsExtras is not null)
            claims.AddRange(claimsExtras);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiracaoMinutos),
            signingCredentials: _credentials
        );

        return _tokenHandler.WriteToken(token);
        
    }

    public DateTime ObterExpiracaoTokenAcesso(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<string> ObterPermissoesPorFuncao(FuncaoEnum? funcao) => funcao switch
    {
        FuncaoEnum.Administrador => new[]
        {
            Permissoes.CardPublicar,
            Permissoes.CardEditar,
            Permissoes.CardListar,
            Permissoes.CardDeletar,
        },
        FuncaoEnum.Curador => new[]
        {
            Permissoes.CardPublicar,
            Permissoes.CardEditar,
            Permissoes.CardListar,
            Permissoes.CardDeletar
        },
        FuncaoEnum.Medico => new[]
        {
            Permissoes.CardPublicar,
            Permissoes.CardEditar,
            Permissoes.CardListar,
            Permissoes.CardDeletar,
        },
        _ => Array.Empty<string>()
    };
}