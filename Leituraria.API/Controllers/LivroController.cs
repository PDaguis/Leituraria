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
        public IActionResult GetBYId([FromRoute] int id)
        {


            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {


            return Ok();
        }

        [HttpPost]
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

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
