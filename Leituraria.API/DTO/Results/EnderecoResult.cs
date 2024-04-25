using Leituraria.Core.Entities;

namespace Leituraria.API.DTO.Results
{
    public class EnderecoResult
    {
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public required string Rua { get; set; }
        public string? Numero { get; set; }
        public required string Bairro { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string Cep { get; set; }
        public required string Pais { get; set; }
        public string? Complemento { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
