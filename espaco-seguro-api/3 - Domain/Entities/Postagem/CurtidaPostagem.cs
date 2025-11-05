using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("curtida_postagem")]
public class CurtidaPostagem
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("postagem_id")]
    public Guid PostagemId { get; set; }
    
    [Column("usuario_id")]
    public Guid UsuarioId { get; set; }
    
    [Column("data_criacao")]
    public DateTime DataCriacao { get; set; }
    
    [Column("data_remocao")] 
    public DateTime? DataRemocao { get; set; }
}