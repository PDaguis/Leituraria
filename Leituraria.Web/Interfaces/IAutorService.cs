using Leituraria.Web.DTO;

namespace Leituraria.Web.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorResult>>? GetAutores();
        Task<AutorResult>? GetById(int id);
        bool Excluir(int id);
        bool Cadastrar(AutorResult livroResult);
    }
}
