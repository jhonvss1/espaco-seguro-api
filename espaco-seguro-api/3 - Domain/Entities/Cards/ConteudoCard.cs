using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

public class ConteudoCard
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(100)]
    [Column("titulo")]
    public string Titulo { get; set; }

    [Required, MaxLength(200)]
    [Column("resumo")]
    public string Resumo { get; set; }

    [Column("corpo")]
    public string Corpo { get; set; }

    [Required, MaxLength(20)]
    [Column("tipo")]
    public string Tipo { get; set; } // text, infographic, video

    [MaxLength(2048)]
    [Column("url_midia")]
    public string UrlMidia { get; set; }

    [Column("tags", TypeName = "jsonb")]
    public string Tags { get; set; } // JSON array
    
    [Column("status"), MaxLength(20)] 
    public StatusConteudo Status { get; set; } = StatusConteudo.Rascunho;
    // builder.Entity<ConteudoCard>()
    // .Property(c => c.Status)
    //     .HasConversion<string>()
    // .HasMaxLength(20);
    
    
    [Required]
    [Column("autor_id")]
    public Guid AutorId { get; set; }

    [Column("data_publicacao")]
    public DateTime? DataPublicacao { get; set; }

    [Column("data_registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    
    [Column("data_atualizacao")]
    public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
    
    //Navegação
    [ForeignKey("autor_id")]
    public Usuario Autor { get; set; }

    public virtual ICollection<FonteCard> Fonte { get; set; } = new List<FonteCard>();
    public virtual ICollection<VerificacaoCard> Verificacao { get; set; } = new List<VerificacaoCard>();
    
}