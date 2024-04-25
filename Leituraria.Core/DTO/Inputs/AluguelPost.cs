using Leituraria.Core.Entities;

namespace Leituraria.Core.DTO.Inputs
{
    public class AluguelPost
    {
        public required DateTime AlugadoEm { get; set; }
        public required DateTime DevolverEm { get; set; }
        public int ClienteId { get; set; }
        public ICollection<int> Livros { get; set; }
    }
}