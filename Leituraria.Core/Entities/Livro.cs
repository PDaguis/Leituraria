using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Entities
{
    public class Livro : EntityBase
    {
        public required string Titulo { get; set; }
        public required DateTime DataPublicacao { get; set; }
        public required string Isbn10 { get; set; }
        public required string Isbn13 { get; set; }
        public required string Idioma { get; set; }
        public required string Descricao { get; set; }
        public required int QuantidadePaginas { get; set; }
        public required decimal Valor { get; set; }
        public string? Imagem { get; set; }

        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }

        public virtual ICollection<Aluguel>? Alugueis { get; set; }
    }
}
