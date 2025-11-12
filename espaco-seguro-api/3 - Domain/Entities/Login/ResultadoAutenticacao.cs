namespace espaco_seguro_api._3___Domain.Entities.Login;

public class ResultadoAutenticacao
{
    public bool Ok { get; set; }
    public Usuario? Usuario { get; set; }
    public string? Erro  { get; set; }

    private ResultadoAutenticacao(bool ok, Usuario? usuario, string erro)
    {
        Ok = ok; 
        Usuario = usuario;
        Erro = erro;
    }
    
    public static ResultadoAutenticacao Sucesso(Usuario u) => new(true, u, null);
    public static ResultadoAutenticacao CredenciaisInvalidas() => new (false, null, "Credenciais inválidas.");
    

}