using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using espaco_seguro_api._3___Domain.Chat;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("sessao_chat")]
public class SessaoChat
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("usuario_id")]
    public Guid? UsuarioId { get; set; }
    
    [Column("anonima")]
    public bool Anonima { get; set; }
    
    [Column("status")]
    [MaxLength(30)]
    public StatusChat StatusChat { get; set; }
    
    [Column("tipo_chat")]
    [MaxLength(30)]
    public TipoChat TipoChat { get; set; }
    
    [Column("data_inicio")]
    public DateTime IniciadoEm { get; set; }
    
    [Column("data_fim")]
    public DateTime? EncerradoEm { get; set; }
    
    //Navegação
    
    public virtual Usuario Usuario { get; set; }
    
    public virtual ICollection<MensagemChat> Mensagens { get; set; } = new List<MensagemChat>();
    
}