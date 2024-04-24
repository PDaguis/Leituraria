using Leituraria.Core.Entities;

namespace Leituraria.API.DTO.Inputs
{
    public class LivroPost
    {
        public required string Titulo { get; set; }
        public required DateTime DataPublicacao { get; set; }
        public required string Isbn10 { get; set; }
        public required string Isbn13 { get; set; }
        public required string Idioma { get; set; }
        public required string Descricao { get; set; }
        public required int QuantidadePaginas { get; set; }
        public required decimal Valor { get; set; }
        public int AutorId { get; set; }
    }
}
