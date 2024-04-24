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
    public class AluguelRepository : GenericRepository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
