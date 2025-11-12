using System.Security.Claims;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._3___Domain.Security;

public interface IFabricadordeToken
{
    string GerarTokenAcesso(Usuario usuario, IEnumerable<Claim>? claims = null);
    DateTime ObterExpiracaoTokenAcesso();
}