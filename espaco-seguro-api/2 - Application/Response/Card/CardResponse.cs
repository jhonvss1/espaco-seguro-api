using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.Response
{
    public class CardResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Corpo { get; set; }
        public string Tipo { get; set; } // text, infographic, video
        public string UrlMidia { get; set; }
        public string[]? Tags { get; set; } // JSON array
        public StatusConteudo Status { get; set; }
        public Guid AutorId { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int QuantidadeFontes { get; set; }
        public int Verificacoes { get; set; }
    }
}
