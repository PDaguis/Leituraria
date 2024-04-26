using Leituraria.API.DTO.Inputs;
using Leituraria.Core.DTO.Results;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetBYId([FromRoute] int id)
        {
            try
            {
                var autor = _autorRepository.GetById(id);

                if (autor == null)
                    return NotFound();

                return Ok(autor);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:int}/livros")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult ObterLivrosPorAutor([FromRoute] int id)
        {
            try
            {
                var autor = _autorRepository.ObterLivrosPorAutor(id);

                if (autor == null)
                    return NotFound();

                return Ok(autor);
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
                var lista = new List<AutorResult>();
                var autores = _autorRepository.GetAll();

                if (autores == null)
                    return NotFound();

                foreach (var item in autores)
                {
                    lista.Add(new AutorResult()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        DataNascimento = item.DataNascimento,
                        Imagem = item.Imagem
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
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
        public IActionResult Put([FromBody] AutorPut input)
        {
            try
            {
                var autor = _autorRepository.GetById(input.Id);

                if (autor == null)
                    return NotFound();

                autor.Nome = input.Nome;
                autor.Descricao = input.Descricao;
                autor.DataNascimento = input.DataNascimento;
                autor.Imagem = input.Imagem;

                _autorRepository.Atualizar(autor);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var autor = _autorRepository.GetById(id);

                if(autor == null)
                    return NotFound();

                _autorRepository.Excluir(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
