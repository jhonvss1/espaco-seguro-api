using espaco_seguro_api._2___Application.Request.Auth;
using espaco_seguro_api._2___Application.Response.LoginResponse;

namespace espaco_seguro_api._2___Application.Interfaces.Auth;

public interface ILoginServiceApp
{
    Task<LoginResponse> LoginAsync(LoginRequestVm loginRequest);
}