using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

public class ComentarioPostagem
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("postagem_id")]
    public Guid PostagemId { get; set; }

    [Required]
    [Column("autor_id")]
    public Guid AutorId { get; set; }

    [Required]
    [Column("conteudo")]
    public string Conteudo { get; set; }

    [Column("anonimo")]
    public bool Anonimo { get; set; } = false;

    [MaxLength(20)]
    [Column("status")]
    public StatusComentarioPostagem Status { get; set; } = StatusComentarioPostagem.Publicado; 

    [Column("contagem_curtidas")]
    public int ContagemCurtidas { get; set; } = 0;

    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    // Navegação
    [ForeignKey("postagem_id")]
    public virtual Postagem Postagem { get; set; }

    [ForeignKey("autor_id")]
    public virtual Usuario Autor { get; set; }
}