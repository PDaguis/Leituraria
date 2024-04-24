using Leituraria.Core.Entities;
using Leituraria.Core.Interfaces;
using Leituraria.Infra.Context;
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
    }
}
