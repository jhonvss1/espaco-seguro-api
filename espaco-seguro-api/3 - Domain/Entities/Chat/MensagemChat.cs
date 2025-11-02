using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using espaco_seguro_api._3___Domain.Chat;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("mensagem_chat")]
public class MensagemChat
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("sessao_id")]
    public Guid SessaoId { get; set; }

    [Column("remetente_id")]
    public Guid? RemetenteId { get; set; } // nullable para mensagens anônimas

    [Required]
    [Column("conteudo")]
    public string Conteudo { get; set; }

    
    [Column("tipo_mensagem"), MaxLength(20)]
    public TipoMensagem TipoMensagem { get; set; } 

    [Column("lida")]
    public bool Lida { get; set; } = false;

    [Column("data_lida")]
    public DateTime? DataLida { get; set; }

    [Column("data_envio")]
    public DateTime DataEnvio { get; set; } = DateTime.UtcNow;

    // Navegação
    [ForeignKey("sessao_id")]
    public virtual SessaoChat Sessao { get; set; }

    [ForeignKey("remetente_id")]
    public virtual Usuario Remetente { get; set; }   
}