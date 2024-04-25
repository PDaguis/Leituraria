using Leituraria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Interfaces
{
    public interface IAutorRepository : IGenericRepository<Autor>
    {
        Autor ObterLivrosPorAutor(int id);
    }
}
