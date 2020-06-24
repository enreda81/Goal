using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GoalSystems.InventoryManager.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Repositorio base con operaciones para Entity Framework
    /// </summary>
    internal class EFBaseRepository<T> : IBaseRepository<T> where T : class
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
