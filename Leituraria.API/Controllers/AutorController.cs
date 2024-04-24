using Leituraria.API.DTO.Inputs;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leituraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBYId([FromRoute] int id)
        {
            var autor = _autorRepository.GetById(id);

            if(autor == null)
                return NotFound();

            return Ok(autor);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var autores = _autorRepository.GetAll();

            if (autores == null)
                return NotFound();

            return Ok(autores);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AutorPost input)
        {
            try
            {
                var autor = new Autor() 
                { 
                    Nome = input.Nome,
                    Descricao = input.Descricao,
                    DataNascimento = input.DataNascimento,
                    Imagem = input.Imagem
                };

                _autorRepository.Cadastrar(autor);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AutorPut input)
        {
            var autor = _autorRepository.GetById(input.Id);

            autor.Nome = input.Nome;
            autor.Descricao = input.Descricao;
            autor.DataNascimento = input.DataNascimento;
            autor.Imagem = input.Imagem;

            _autorRepository.Atualizar(autor);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
