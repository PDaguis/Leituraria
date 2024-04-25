using Leituraria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.DTO.Results
{
    public class AutorResult
    {
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public ICollection<LivroResult>? Livros { get; set; }
        public string? Imagem { get; set; }
    }
}
