using Leituraria.Core.Entities;

namespace Leituraria.API.DTO.Results
{
    public class AutorLivrosResult
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public ICollection<Livro>? Livros { get; set; }
        public string? Imagem { get; set; }
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
    }
}
