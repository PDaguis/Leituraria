using Leituraria.API.DTO.Inputs;
using Leituraria.API.DTO.Results;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Leituraria.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leituraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetBYId([FromRoute] int id)
        {
            try
            {
                var cliente = _clienteRepository.GetById(id);

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:int}/alugueis")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult ObterAlugueisPorCliente([FromRoute] int id)
        {
            try
            {
                var cliente = _clienteRepository.ObterAlugueisPorCliente(id);

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
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
                var clienteResult = new List<ClienteResult>();

                var clientes = _clienteRepository.GetAll();

                foreach (var cliente in clientes)
                {
                    clienteResult.Add(new ClienteResult()
                    {
                        Id = cliente.Id,
                        CadastradoEm = cliente.CadastradoEm,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Cpf = cliente.Cpf,
                        DataNascimento = cliente.DataNascimento
                    });
                }

                if (clientes == null)
                    return NotFound();

                return Ok(clientes);
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
        public IActionResult Post([FromBody] ClientePost input)
        {
            try
            {
                var autor = new Cliente()
                {
                    Nome = input.Nome,
                    Email = input.Email,
                    Cpf = input.Cpf,
                    DataNascimento = input.DataNascimento
                };

                _clienteRepository.Cadastrar(autor);

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
        public IActionResult Put([FromBody] ClientePut input)
        {
            try
            {
                var cliente = _clienteRepository.GetById(input.Id);

                if (cliente == null)
                    return NotFound();

                cliente.Nome = input.Nome;
                cliente.Email = input.Email;
                cliente.Cpf = input.Cpf;
                cliente.DataNascimento = input.DataNascimento;

                _clienteRepository.Atualizar(cliente);

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
                var autor = _clienteRepository.GetById(id);

                if (autor == null)
                    return NotFound();

                _clienteRepository.Excluir(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
