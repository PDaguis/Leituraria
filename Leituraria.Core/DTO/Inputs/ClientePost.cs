using Leituraria.Core.Entities;

namespace Leituraria.Core.DTO.Inputs
{
    public class ClientePost
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
