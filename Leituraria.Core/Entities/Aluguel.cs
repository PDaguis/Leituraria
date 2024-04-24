using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Entities
{
    public class Aluguel : EntityBase
    {
        public required DateTime AlugadoEm { get; set; }
        public required DateTime DevolverEm { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Livro> Livros { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }

        public decimal ObterValorTotal()
        {
            return Livros.Sum(x => x.Valor);
        }
    }
}
