using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("postagem")]
public class Postagem
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column("autor_id")]
    public Guid AutorId { get; set; }

    [Required]
    [Column("conteudo")]
    public string Conteudo { get; set; }

    [Column("anonimo")]
    public bool Anonimo { get; set; } = false;

    [MaxLength(20)] 
    [Column("status_postagem")]
    public StatusPostagem StatusPostagem { get; set; } = StatusPostagem.Rascunho; 
    [Column("tags")]
    public string[]? Tags { get; set; }

    [Column("contagem_curtidas")]
    public int ContagemCurtidas { get; set; } = 0;
    
    [Column("contagem_comentarios")]
    public int ContagemComentarios { get; set; } = 0;

    [Column("data_publicacao")]
    public DateTime DataPublicacao { get; set; }
    
    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    [Column("data_atualizacao")]
    public DateTime? DataAtualizacao { get; set; } = DateTime.UtcNow;
    
    //Navegação
     [ForeignKey(nameof(AutorId))]
    public virtual Usuario Autor { get; set; }
    
    public virtual ICollection<ComentarioPostagem> Comentarios { get; set; }
    
}