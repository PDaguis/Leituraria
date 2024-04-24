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
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
        }

        public void Cadastrar(T entidade)
        {
            entidade.CadastradoEm = DateTime.Now;
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            _dbSet.Remove(GetById(id));
        }
    }
}
