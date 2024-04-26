using System.Text.Json.Serialization;

namespace Leituraria.Web.DTO
{
    public class AutorResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cadastradoEm")]
        public DateTime CadastradoEm { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("dataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [JsonPropertyName("imagem")]
        public string? Imagem { get; set; }

        public IFormFile? ImagemFile { get; set; }
    }
}
