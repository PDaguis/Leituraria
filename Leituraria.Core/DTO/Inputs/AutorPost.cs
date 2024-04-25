using Leituraria.Core.Entities;

namespace Leituraria.Core.DTO.Inputs
{
    public class AutorPost
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Imagem { get; set; }
    }
}
