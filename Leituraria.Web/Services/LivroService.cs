using Leituraria.Web.DTO;
using Leituraria.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Leituraria.Web.Services
{
    public class LivroService : ILivroService
    {
        private readonly HttpClient _httpClient;

        public LivroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public bool Cadastrar(LivroResult livroResult)
        {
            try
            {
                var jsonRequest = new StringContent(JsonSerializer.Serialize(livroResult), Encoding.UTF8, Application.Json);

                var response = _httpClient.PostAsync("/Livro", jsonRequest).Result.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            var response = _httpClient.DeleteAsync($"Livro/{id}").Result;

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<LivroResult> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"Livro/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonResult = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<LivroResult>(jsonResult);

            return data;
        }

        public async Task<IEnumerable<LivroResult>> GetLivros()
        {
            var response = await _httpClient.GetAsync("Livro");


            if (!response.IsSuccessStatusCode)
                return null;

            var jsonResult = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<LivroResult>>(jsonResult);

            return data;
        }
    }
}
