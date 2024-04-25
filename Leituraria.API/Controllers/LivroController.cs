using Leituraria.API.DTO.Inputs;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

                return Ok(livro);
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
                var livros = _livroRepository.GetAll();

                if (livros == null)
                    return NotFound();

                return Ok(livros);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
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

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
