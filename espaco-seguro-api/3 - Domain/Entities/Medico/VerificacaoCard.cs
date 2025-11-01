using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

public class VerificacaoCard
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("cartao_id")]
    public Guid CartaoId { get; set; }

    [Required]
    [Column("curador_id")]
    public Guid MedicoId { get; set; }

    [Column("fonte_primaria_ok")]  
    public bool FontePrimariaOk { get; set; } = false;
    
    [Column("afirmacoes_conferidas")]
    public bool AfirmacoesConferidas { get; set; } = false;

    [Column("linguagem_acessivel")]
    public bool LinguagemAcessivel { get; set; } = false;

    [Column("sem_prescricao_medica")]
    public bool SemPrescricaoMedica { get; set; } = false;

    [Column("sem_alarmismo")]
    public bool SemAlarmismo { get; set; } = false;

    [Column("observacoes")]
    public string Observacoes { get; set; }

    [Column("resultado")]
    [MaxLength(20)] public StatusVerificacaoCard Resultado { get; set; } = StatusVerificacaoCard.PrecisaRevisao;

    [Column("data_atualizacao")]
    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

    [Column("data_verificacao")]
    public DateTime VerificadoEm { get; set; } = DateTime.UtcNow;
    
    // Navegação
    [ForeignKey("cartao_id")]
    public virtual ConteudoCard Cartao { get; set; }

    [ForeignKey("medico_id")]
    public virtual Usuario Medico { get; set; }
}