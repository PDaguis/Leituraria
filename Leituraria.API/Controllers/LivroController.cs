using Leituraria.API.DTO.Inputs;
using Leituraria.Core.DTO.Results;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Leituraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetBYId([FromRoute] int id)
        {
            try
            {
                var livro = _livroRepository.GetById(id);

                if (livro == null)
                    return NotFound();

                var livroResult = new LivroResult()
                {
                    Id = livro.Id,
                    CadastradoEm = livro.CadastradoEm,
                    Titulo = livro.Titulo,
                    DataPublicacao = livro.DataPublicacao,
                    Isbn10 = livro.Isbn10,
                    Isbn13 = livro.Isbn13,
                    Idioma = livro.Idioma,
                    Descricao = livro.Descricao,
                    QuantidadePaginas = livro.QuantidadePaginas,
                    Valor = livro.Valor.ToString(),
                    Imagem = livro.Imagem
                };

                return Ok(livroResult);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<LivroResult>();
                var livros = _livroRepository.GetAll();

                if (livros == null)
                    return NotFound();

                foreach (var item in livros)
                {
                    lista.Add(new LivroResult()
                    {
                        Id = item.Id,
                        Titulo = item.Titulo,
                        Descricao = item.Descricao,
                        QuantidadePaginas = item.QuantidadePaginas,
                        Valor = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", item.Valor).Replace(";", ""),
                        Imagem = item.Imagem,
                        DataPublicacao = item.DataPublicacao
                    });
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] LivroPost input)
        {
            try
            {
                var livro = new Livro()
                {
                    Titulo = input.Titulo,
                    DataPublicacao = input.DataPublicacao,
                    Isbn10 = input.Isbn10,
                    Isbn13 = input.Isbn13,
                    Idioma = input.Idioma,
                    Descricao = input.Descricao,
                    QuantidadePaginas = input.QuantidadePaginas,
                    Valor = input.Valor,
                    AutorId = input.AutorId
                };

                _livroRepository.Cadastrar(livro);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] LivroPut input)
        {
            try
            {
                var livro = _livroRepository.GetById(input.Id);

                if (livro == null)
                    return NotFound();

                livro.Titulo = input.Titulo;
                livro.DataPublicacao = input.DataPublicacao;
                livro.Isbn10 = input.Isbn10;
                livro.Isbn13 = input.Isbn13;
                livro.Idioma = input.Idioma;
                livro.Descricao = input.Descricao;
                livro.QuantidadePaginas = input.QuantidadePaginas;
                livro.Valor = input.Valor;

                _livroRepository.Atualizar(livro);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var livro = _livroRepository.GetById(id);

                if (livro == null)
                    return NotFound();

                _livroRepository.Excluir(id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
