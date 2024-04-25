using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Entities
{
    public class Autor : EntityBase
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public virtual ICollection<Livro>? Livros { get; set; }
        public string? Imagem { get; set; }
    }
}
