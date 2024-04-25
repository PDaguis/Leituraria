using Leituraria.Core.Entities;

namespace Leituraria.API.DTO.Results
{
    public class AluguelResult
    {
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public required DateTime AlugadoEm { get; set; }
        public required DateTime DevolverEm { get; set; }
        public int ClienteId { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
