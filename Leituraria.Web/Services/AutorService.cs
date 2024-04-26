using Leituraria.Web.DTO;
using Leituraria.Web.Interfaces;
using System.Text.Json;

namespace Leituraria.Web.Services
{
    public class AutorService : IAutorService
    {
        private readonly HttpClient _httpClient;

        public AutorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool Cadastrar(AutorResult livroResult)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AutorResult>>? GetAutores()
        {
            try
            {
                var response = await _httpClient.GetAsync("Autor");

                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonResult = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<AutorResult>>(jsonResult);

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<AutorResult>? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
