using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace espaco_seguro_api._3___Domain.Entities;

[Table("conteudo_card")]
public class ConteudoCard
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(100)]
    [Column("titulo")]
    public string Titulo { get; set; }

    [MaxLength(200)]
    [Column("resumo")]
    public string Resumo { get; set; }

    [Column("corpo")]
    public string Corpo { get; set; }

    [MaxLength(20)]
    [Column("tipo")]
    public string Tipo { get; set; } // text, infographic, video

    [MaxLength(2048)]
    [Column("url_midia")]
    public string UrlMidia { get; set; }

    [Column("tags", TypeName = "text[]")]
    public string[]? Tags { get; set; }
    
    [Column("status"), MaxLength(20)] 
    public StatusConteudo Status { get; set; } = StatusConteudo.Rascunho;
    
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
    public Usuario Autor { get; set; }

    public virtual ICollection<FonteCard> Fonte { get; set; } = new List<FonteCard>();
    public virtual ICollection<VerificacaoCard> Verificacao { get; set; } = new List<VerificacaoCard>();


    #region Metodos

    public void CriadoPor(Guid autorId)
    {
        AutorId = autorId;
        Status = StatusConteudo.Rascunho;
        DataRegistro = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void EnviarParaRevisao(Guid solicitanteId, Func<Guid,bool> temPermissaoEnviar)
    {
        if (AutorId != solicitanteId && !temPermissaoEnviar(solicitanteId))
            throw new InvalidOperationException("Apenas o autor ou quem tem permisão pode enviar.");
        
        if (Status != StatusConteudo.Rascunho && Status != StatusConteudo.Pendente)
            throw new InvalidOperationException("Só é possível enviar parta revisão se estiver em rascunho ou pendente.");
        
        Status = StatusConteudo.Pendente;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void IniciarRevisao(Guid revisorId, Func<Guid, bool> temPermissaoRevisar)
    {
        if (!temPermissaoRevisar(revisorId))
        {
            throw new InvalidOperationException("Sem permissão para revisar");
        }

        if (Status != StatusConteudo.Pendente)
        {
            throw new InvalidOperationException("Só é possível iniciar revisão se o card estiver pendente.");
        }

        Status = StatusConteudo.Revisao;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void Publicar(Guid aprovadorId, Func<Guid, bool> temPermissaoPublicar)
    {
        if (!temPermissaoPublicar(aprovadorId))
        {
            throw new InvalidOperationException("Sem permissão para publicar.");
        }

        if (Status != StatusConteudo.Revisao)
        {
            throw new InvalidOperationException("Só é possível publicar o card a partir de Revisão.");
        }
        
        Status = StatusConteudo.Publicado;
        DataRegistro =  DateTime.UtcNow;
        DataPublicacao = DateTime.UtcNow;
    }

    public void Arquivar(Guid solicitanteId, Func<Guid, bool> temPermissaoArquivar)
    {
        if (!temPermissaoArquivar(solicitanteId))
            throw new InvalidOperationException("Sem permissão para arquivar.");

        if (Status == StatusConteudo.Arquivado)
            throw new InvalidOperationException("Já está arquivado.");

        Status = StatusConteudo.Arquivado;
        DataAtualizacao = DateTime.UtcNow;
    }
    
    
    #endregion
    
}