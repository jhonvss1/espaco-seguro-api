using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("usuario")]
public class Usuario
{
    [Key] 
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(150)]
    [Column("email")]
    public string Email  { get; set; }
    
    [Required, MaxLength(255)]
    [Column("senha_hash")]
    public string? SenhaHash { get; set; }
    
    [Required, MaxLength(150)]
    [Column("nome")]
    public string Nome { get; set; }
    
    [Column("data_nascimento")]
    public DateOnly? DataNascimento { get; set; }
    
    [MaxLength(11)]
    [Column("cpf")]
    public string? Cpf  { get; set; }
    
    [MaxLength(20)]
    [Column("telefone")]
    public string? Telefone  { get; set; }

    [Column("funcao")] 
    public FuncaoEnum? Funcao { get; set; } = FuncaoEnum.Usuario; 
    
    [Column("status")]
    public StatusUsuario StatusUsuario { get; set; } = StatusUsuario.Pendente;
    
    [MaxLength(500)]
    [Column("foto")]
    public string? Foto { get; set; }
    
    [Column("aceitou_termos")]
    public bool? AceitouTermos { get; set; } = false;
    
    [Column("data_aceite_termos")]
    public DateTime? DataAceiteTermos { get; set; } = DateTime.UtcNow;
    
    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    
    [Column("data_atualizacao")]
    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
    
    [Column("ultimo_acesso")]
    public DateTime? UltimoAcesso { get; set; } = DateTime.UtcNow;
    
    //Navegação
    public virtual ICollection<ConteudoCard> Cartoes { get; set; } = new  List<ConteudoCard>();
    public virtual ICollection<Postagem> Postagens { get; set; } = new   List<Postagem>();
    public virtual ICollection<SessaoChat> Sessoes { get; set; } = new   List<SessaoChat>();
    public virtual Medico? Medico { get; set; }
    
}