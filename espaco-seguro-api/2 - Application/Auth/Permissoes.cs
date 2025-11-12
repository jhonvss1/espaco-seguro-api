namespace espaco_seguro_api._3___Domain.Security;

public static class Permissoes
{
    #region Cards
    public const string CardCriar            = "Card.Criar";
    public const string CardEnviarRevisao    = "Card.EnviarRevisao";
    public const string CardRevisar          = "Card.Revisar";       // colocar em Revisão
    public const string CardPublicar         = "Card.Publicar";
    public const string CardArquivar         = "Card.Arquivar";
    public const string CardListar           = "Card.Listar";
    public const string CardEditar           = "Card.Editar";
    public const string CardDeletar          = "Card.Deletar";
    #endregion

    #region Postagem
    public const string ListarPostagem = "Postagem.ListarPostagem";
    public const string PostarPostagem = "Postagem.PostarPostagem";
    public const string ExcluirPostagem  = "Postagem.ExcluirPostagem";
    public const string EditarPostagem = "Postagem.EditarPostagem";
    #endregion

    #region Comentarios
    public const string ComentarioCriar = "Comentario.Criar";
    public const string ComentarioListar = "Comentario.Listar";
    public const string ComentarioDeletar = "Comentario.Deletar";
    #endregion

    #region Curtidas
    public const string Curtir = "Curtir";
    public const string Descurtir = "Descutir";
    #endregion


}