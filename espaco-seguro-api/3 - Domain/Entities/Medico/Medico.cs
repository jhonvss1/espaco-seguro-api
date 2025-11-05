using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;
[Table("medico")]
public class Medico
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [MaxLength(20)]
    [Column("crm")]
    public string Crm { get; set; }
    
    [MaxLength(2)]
    [Column("uf_crm")]
    public string UfCrm { get; set; }
    
    [Column("usuario_id")]
    public Guid UsuarioId { get; set; }
    
    [MaxLength(100)]
    [Column("especialidade")]
    public string Especialidade { get; set; }
    
    [Column("status_verificacao")]
    public StatusMedico StatusMedico { get; set; } = StatusMedico.Pendente;
    
    [MaxLength(255)]
    [Column("observacoes")]
    public string Observacoes { get; set; }
    
    [Column("data_verificacao")]
    public DateTime? DataVerificacao { get; set; }
    
    [Column("verificado_por")]
    public Guid? VerificadoPor { get; set; }
    
    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    
    //Navegação
    [ForeignKey(nameof(UsuarioId))]
    public virtual Usuario Usuario { get; set; }
    
    public virtual ICollection<CertificacaoMedico> Certificacoes { get; set; } = new List<CertificacaoMedico>();
    
    
}