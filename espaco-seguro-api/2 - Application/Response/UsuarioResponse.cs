using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.ViewModels;

public class UsuarioResponse
{   
    public Guid? Id { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public DateOnly? DataNascimento { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string? Foto { get; set; }
    public FuncaoEnum? Funcao { get; set; }
    public StatusUsuario StatusUsuario { get; set; }
    public bool AceitouTermos { get; set; }
    public DateTime? DataAceiteTermos { get; set; }
    public DateTime DataRegistro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime? UltimoAcesso { get; set; }
    public int QuantidadeCartoes { get; set; }
    public int QuantidadePostagens { get; set; }
    public int QuantidadeSessoes { get; set; }
}