using Leituraria.Core.DTO.Results;
using Leituraria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        ClienteResult ObterAlugueisPorCliente(int id);
    }
}
