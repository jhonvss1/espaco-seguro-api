using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("comentario_postagem")]
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
    public StatusComentarioPostagem StatusComentarioPostagem { get; set; } = StatusComentarioPostagem.Publicado; 

    [Column("contagem_curtidas")]
    public int ContagemCurtidas { get; set; } = 0;

    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    // Navegação
    [ForeignKey(nameof(PostagemId))]
    public virtual Postagem Postagem { get; set; }

    [ForeignKey(nameof(AutorId))]
    public virtual Usuario Autor { get; set; }
}