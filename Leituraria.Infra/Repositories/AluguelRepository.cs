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
    public class AluguelRepository : GenericRepository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Aluguel ObterComLivros(int id)
        {
            var aluguel = _context.Aluguel
                .Include(a => a.Livros)
                 .FirstOrDefault(a => a.Id == id)
                 ?? throw new Exception("Cliente não encontrado");

            aluguel.Livros = aluguel.Livros.Select(a =>
            {
                a.Alugueis = null;
                return a;
            }).ToList();

            return aluguel;
        }
    }
}
