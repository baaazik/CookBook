using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using Model.Repository;

namespace Data.Repository
{
    /// <summary>
    /// Реализация универсального репозитория
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>, new()
    {
        Context _ctx;
        DbSet<TEntity> _dbSet;

        public GenericRepository(Context ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity? FindById(TId id)
        {
            return _dbSet.FirstOrDefault(x =>
                EqualityComparer<TId>.Default.Equals(x.Id, id));
        }

        public TEntity? Query(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveById(TId id)
        {
            var obj = new TEntity() { Id = id };
            _dbSet.Remove(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _ctx.SaveChanges();
        }
    }
}
