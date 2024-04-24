using Leituraria.Core.Entities;

namespace Leituraria.API.DTO.Inputs
{
    public class AutorPut
    {
        public int Id { get; set; }
        public  string Nome { get; set; }
        public  string Descricao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Imagem { get; set; }
    }
}
