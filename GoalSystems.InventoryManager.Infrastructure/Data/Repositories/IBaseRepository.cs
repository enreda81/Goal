using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GoalSystems.InventoryManager.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Interfaz que deben implementar las diferentes implementaciones del patrón repositorio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Agrega una entidad
        /// </summary>
        /// <param name="entity"></param>
        T Add(T entity);

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad por su identificador
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Proporciona una entidad por su identificador
        /// </summary>
        /// <param name="id"></param>        
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Realiza una búsqueda
        /// </summary>
        /// <param name="predicate"></param>        
        /// <returns></returns>
        IList<T> GetQuery(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// Libera el contexto del repositorio
        /// </summary>
        void Release();

        /// <summary>
        /// Guarda los cambios en el medio de persistencia
        /// </summary>
        void Save();
    }
}
