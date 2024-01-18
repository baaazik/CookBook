using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    /// <summary>
    /// Интерфейс универсального репозитория
    /// </summary>
    /// <typeparam name="TEntity">Класс сущности</typeparam>
    /// /// <typeparam name="TEntity">Тип ключа</typeparam>
    public interface IGenericRepository<TEntity, TId>
            where TEntity : class, IEntity<TId>, new()
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveById(TId id);
        TEntity? FindById(TId id);
        public TEntity? Query(Func<TEntity, bool> predicate);
        void Save();
    }
}
