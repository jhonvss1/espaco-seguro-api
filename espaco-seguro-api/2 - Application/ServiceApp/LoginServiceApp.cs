using espaco_seguro_api._2___Application.Interfaces.Auth;
using espaco_seguro_api._2___Application.Request.Auth;
using espaco_seguro_api._2___Application.Response.LoginResponse;

namespace espaco_seguro_api._2___Application.ServiceApp;

public class LoginServiceAppApp() : ILoginServiceApp
{
    public Task<LoginResponse> Login(LoginRequestVm loginRequest)
    {
        
    }
}