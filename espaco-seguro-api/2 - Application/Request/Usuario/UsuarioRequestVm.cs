using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.Request;

public class UsuarioRequestVm
{
    public string? Email { get; set; }
    public string? Nome { get; set; }
    public DateOnly? DataNascimento { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string? Foto { get; set; }
    public bool AceitaTermos { get; set; }
    public FuncaoEnum Funcao { get; set; } 
    public string Senha { get; set; }
    public string ConfirmarSenha { get; set; }
}