using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Entities
{
    public class Cliente : EntityBase
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public ICollection<Endereco>? Enderecos { get; set; }
        public ICollection<Aluguel>? Alugueis { get; set; }
    }
}
