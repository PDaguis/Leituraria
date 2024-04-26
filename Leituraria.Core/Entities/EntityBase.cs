using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Core.Entities
{
    public class EntityBase
    {
        public int Id { get; }
        public DateTime CadastradoEm { get; set; }

        //public EntityBase()
        //{
        //    Id = Guid.NewGuid();
        //    CadastradoEm = DateTime.Now;
        //}
    }
}
