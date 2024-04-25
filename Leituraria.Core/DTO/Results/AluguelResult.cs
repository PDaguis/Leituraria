using Leituraria.Core.Entities;

namespace Leituraria.Core.DTO.Results
{
    public class AluguelResult
    {
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public required DateTime AlugadoEm { get; set; }
        public required DateTime DevolverEm { get; set; }
        public int ClienteId { get; set; }
        public ICollection<LivroResult> Livros { get; set; }
    }
}
