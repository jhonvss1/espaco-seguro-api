using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("fonte_card")]
public class FonteCard
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("cartao_id")]
    public Guid CartaoId { get; set; }

    [Required, MaxLength(200)]
    [Column("titulo")]
    public string Titulo { get; set; }

    [Required, MaxLength(2048)]
    [Column("url")]
    public string Url { get; set; }

    [Required, MaxLength(100)]
    [Column("publicador")]
    public string Publicador { get; set; }

    [Column("fonte_primaria")]
    public bool FontePrimaria { get; set; } = false;
    
    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    
    [Column("data_atualizacao")]
    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

    // Navegação
    public virtual ConteudoCard Cartao { get; set; }
}