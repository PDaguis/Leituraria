using System.Text.Json.Serialization;

namespace Leituraria.Web.DTO
{
    public class LivroResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cadastradoEm")]
        public DateTime CadastradoEm { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("dataPublicacao")]
        public DateTime DataPublicacao { get; set; }

        [JsonPropertyName("isbn10")]
        public string Isbn10 { get; set; }

        [JsonPropertyName("isbn13")]
        public string Isbn13 { get; set; }

        [JsonPropertyName("idioma")]
        public string Idioma { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("quantidadePaginas")]
        public int QuantidadePaginas { get; set; }

        [JsonPropertyName("valor")]
        public string Valor { get; set; }

        [JsonPropertyName("imagem")]
        public string Imagem { get; set; }
    }
}
