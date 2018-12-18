using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChatQJW.Core.Data;

namespace WebChatQJW.Core.Repository.Entities
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DataContext DbContexto = null;
        DbSet<TEntity> _dbSet;

        public RepositoryBase(DataContext ctx)
        {
            DbContexto = ctx;
            _dbSet = DbContexto.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public void Dispose()
        {
            DbContexto.Dispose();
            _dbSet = null;
        }

    }
}
