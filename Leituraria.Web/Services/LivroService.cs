using Leituraria.Web.DTO;
using Leituraria.Web.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Leituraria.Web.Services
{
    public class LivroService : ILivroService
    {
        private readonly HttpClient _httpClient;

        public LivroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LivroResult>> GetLivros()
        {
            var response = await _httpClient.GetAsync("api/Livro");

            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<LivroResult>>(jsonResult);

            return data;
        }
    }
}
