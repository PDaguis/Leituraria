using Leituraria.Core.DTO.Results;
using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Leituraria.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Infra.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ClienteResult ObterAlugueisPorCliente(int id)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Cliente não encontrado");

            return new ClienteResult()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                Alugueis = cliente.Alugueis?.Select(a => new AluguelResult()
                {
                    Id = a.Id,
                    CadastradoEm = a.CadastradoEm,
                    AlugadoEm = a.AlugadoEm,
                    DevolverEm = a.DevolverEm,
                    ClienteId = a.ClienteId,
                    Livros = a.Livros.Select(l => new LivroResult()
                    {
                        Id = l.Id,
                        Titulo = l.Titulo,
                        Valor = l.Valor,
                        Autor = new AutorResult()
                        {
                            Id = l.Autor.Id,
                            Nome = l.Autor.Nome
                        }
                    }).ToList()
                }).ToList()
            };
        }
    }
}
