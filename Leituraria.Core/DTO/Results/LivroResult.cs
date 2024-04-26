using Leituraria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.DTO.Results
{
    public class LivroResult
    {
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
        public string Idioma { get; set; }
        public string Descricao { get; set; }
        public int QuantidadePaginas { get; set; }
        public string Valor { get; set; }
        public string Imagem { get; set; }

        public AutorResult Autor { get; set; }
        public int AutorId { get; set; }
    }
}
