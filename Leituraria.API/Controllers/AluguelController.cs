using Leituraria.API.DTO.Inputs;
using Leituraria.Core.DTO.Results;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leituraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly ILivroRepository _livroRepository;

        public AluguelController(IAluguelRepository aluguelRepository, ILivroRepository livroRepository)
        {
            _aluguelRepository = aluguelRepository;
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
                var aluguel = _aluguelRepository.GetById(id);

                if (aluguel == null)
                    return NotFound();

                return Ok(aluguel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/livros/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetComLivros([FromRoute] int id)
        {
            try
            {
                var aluguel = _aluguelRepository.ObterComLivros(id);

                if (aluguel == null)
                    return NotFound();

                return Ok(aluguel);
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
                var alugueis = _aluguelRepository.GetAll();

                if (alugueis == null)
                    return NotFound();

                return Ok(alugueis);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] AluguelPost input)
        {
            try
            {
                var aluguel = new Aluguel()
                {
                    AlugadoEm = input.AlugadoEm,
                    DevolverEm = input.DevolverEm,
                    ClienteId = input.ClienteId
                };

                foreach (var item in input.Livros)
                {
                    var livro = _livroRepository.GetById(item);
                    aluguel.AddLivros(livro);
                }

                _aluguelRepository.Cadastrar(aluguel);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //[HttpPut]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public IActionResult Put([FromBody] ClientePut input)
        //{
        //    try
        //    {
        //        var cliente = _aluguelRepository.GetById(input.Id);

        //        if (cliente == null)
        //            return NotFound();

        //        cliente.Nome = input.Nome;
        //        cliente.Email = input.Email;
        //        cliente.Cpf = input.Cpf;
        //        cliente.DataNascimento = input.DataNascimento;

        //        _aluguelRepository.Atualizar(cliente);

        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var autor = _aluguelRepository.GetById(id);

                if (autor == null)
                    return NotFound();

                _aluguelRepository.Excluir(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
