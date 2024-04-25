using Leituraria.Core.Entities;

namespace Leituraria.Core.DTO.Results
{
    public class ClienteResult
    {
        public int Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Cpf { get; set; }
        public ICollection<EnderecoResult>? Enderecos { get; set; }
        public ICollection<AluguelResult>? Alugueis { get; set; }
    }
}
