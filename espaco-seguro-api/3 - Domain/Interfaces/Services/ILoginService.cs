using espaco_seguro_api._3___Domain.Entities.Login;

namespace espaco_seguro_api._3___Domain.Interfaces.Services;

public interface ILoginService
{
    Task<ResultadoAutenticacao> AutenticarAsync(string email, string senha);
}