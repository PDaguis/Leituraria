using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Entities
{
    public class Pedido : EntityBase
    {
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }
    }
}
