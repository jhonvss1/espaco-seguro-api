using espaco_seguro_api._3___Domain;

namespace espaco_seguro_api._2___Application.Request
{
    public class CardResquestVm
    {
        public string? Titulo { get; set; }
        public string? Resumo { get; set; }
        public string? Corpo { get; set; }
        public string? Tipo { get; set; }
        public string? UrlMidia { get; set; }
        public string? Tags { get; set; }
        public StatusConteudo? Status { get; set; }

    }
}
