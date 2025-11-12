namespace espaco_seguro_api._2___Application.Response.LoginResponse;

public class LoginResponse
{
    public string TokenAcesso { get; set; } = default;
    public DateTime ExpiracaoTokenAcesso { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Funcao { get; set; }
}