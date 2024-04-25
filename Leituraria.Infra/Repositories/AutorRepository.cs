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
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        public AutorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Autor ObterLivrosPorAutor(int id)
        {
            var autor = _context.Autores
                .Include(a => a.Livros)
                .FirstOrDefault(a => a.Id == id);

            autor.Livros = autor.Livros.Select(a =>
            {
                a.Autor = null;
                return a;
            }).ToList();

            return autor;
        }
    }
}
