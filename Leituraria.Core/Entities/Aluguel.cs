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
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }

        public decimal ObterValorTotal()
        {
            return Livros.Sum(x => x.Valor);
        }

        public void AddLivros(Livro livro)
        {
            if (livro == null)
                return;

            if(Livros == null)
                Livros = new List<Livro>();

            Livros.Add(livro);
        }
    }
}
