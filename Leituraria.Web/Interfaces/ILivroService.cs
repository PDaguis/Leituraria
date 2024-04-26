using Leituraria.Web.DTO;

namespace Leituraria.Web.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroResult>>? GetLivros();
        Task<LivroResult>? GetById(int id);
        bool Excluir(int id);

        bool Cadastrar(LivroResult livroResult);
    }
}
