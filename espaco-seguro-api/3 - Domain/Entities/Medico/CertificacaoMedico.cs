using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;
[Table("certificacao_medico")]
public class CertificacaoMedico
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("medico_id")]
    public Guid MedicoId { get; set; }

    [Required, MaxLength(50)]
    [Column("tipo_certificacao")]
    public TipoCertificado TipoCertificado { get; set; } // crm, rqe, titulo_especialista

    [Required, MaxLength(100)]
    [Column("numero_documento")]
    public string NumeroDocumento { get; set; }

    [MaxLength(500)]
    [Column("url_certificado")]
    public string UrlDocumento { get; set; }

    [Column("data_emissao")]
    public DateTime? DataEmissao { get; set; }

    [Column("data_validadade")]
    public DateTime? DataValidade { get; set; }

    [MaxLength(20)] [Column("status")] 
    public StatusCertificacao StatusCertificacao { get; set; } = StatusCertificacao.Pendente;

    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    // Navegação
    [ForeignKey(nameof(MedicoId))]
    public virtual Medico Medico { get; set; }
}