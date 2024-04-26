using Leituraria.Web.DTO;

namespace Leituraria.Web.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroResult>> GetLivros();
    }
}
