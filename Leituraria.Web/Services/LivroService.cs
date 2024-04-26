﻿using Leituraria.Web.DTO;
using Leituraria.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
