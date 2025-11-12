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
            new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, usuario.Email),
            new(JwtRegisteredClaimNames.UniqueName, usuario.Nome),
            new(ClaimTypes.Role, usuario.Funcao.ToString())
        };

        var permissoes = ObterPermissoesPorFuncao(usuario.Funcao);
        claims.AddRange(permissoes.Select(p => new Claim("perm", p)));

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

    public DateTime ObterExpiracaoTokenAcesso() =>
        DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiracaoMinutos);

    public static IEnumerable<string> ObterPermissoesPorFuncao(FuncaoEnum? funcao) => funcao switch
    {
        FuncaoEnum.Administrador => new[]
        {
            Permissoes.CardCriar,
            Permissoes.CardEnviarRevisao,
            Permissoes.CardRevisar,
            Permissoes.CardPublicar,
            Permissoes.CardArquivar,
            Permissoes.CardListar,
            Permissoes.CardEditar,
            Permissoes.CardDeletar
        },
        FuncaoEnum.Medico => new[]
        {
            Permissoes.CardCriar,
            Permissoes.CardEnviarRevisao,
            Permissoes.CardRevisar,
            Permissoes.CardPublicar,
            Permissoes.CardListar,
            Permissoes.CardEditar
        },
        FuncaoEnum.Curador => new[]
        {
            Permissoes.CardCriar,
            Permissoes.CardEnviarRevisao,
            Permissoes.CardListar,
            Permissoes.CardEditar
        },
        _ => Array.Empty<string>()
    };
}
