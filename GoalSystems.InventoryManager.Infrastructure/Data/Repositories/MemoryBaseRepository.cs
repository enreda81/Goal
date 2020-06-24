using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GoalSystems.InventoryManager.Infrastructure.CrossCutting.ExtensionMethod;

namespace GoalSystems.InventoryManager.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación base del patrón Repositorio cuya para persistencia reside en memoria
    /// </summary>
    internal class MemoryBaseRepository<T> : NonGenericFakeBaseRepository, IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        internal MemoryBaseRepository() { }


        /// <summary>
        /// Devuelve la colección de entidades de un tipo concreto
        /// </summary>
        protected List<Object> Entities
        {
            get
            {
                if (!Context.ContainsKey(typeof(T)))
                {
                    Context.Add(typeof(T), new List<Object>());
                }
                return Context[typeof(T)];
            }
        }

        /// <summary>
        /// Agrega una entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            entity.ThrowIfNull<T>("No se pueden agregar elementos nulos");
            Entities.Add(entity);
            return (T)Entities.LastOrDefault();
        }


        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        public void Delete(int id)
        {
            id.ThrowIfLessThan(0);
            T entity = GetById(id);
            Delete(entity);
        }

        
        /// <summary>
        /// Borra una entidad
        /// </summary>
        /// <param name="entity">Emtidad</param>
        public void Delete(T entity)
        {
            entity.ThrowIfNull<T>("No se pueden borrar elementos nulos");
            Entities.Remove(entity);
        }
        

        /// <summary>
        /// Retorna el listado de todas las entidades
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return Entities.Cast<T>().ToList();
        }

        
        /// <summary>
        /// Retorna una entidad a partir de su identificador
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            id.ThrowIfLessThan(0);
            var idProperty = GetIdProperty();
            return Entities.Cast<T>().FirstOrDefault(x => (int)idProperty.GetValue(x, null) == id);
        }


        /// <summary>
        /// Proporciona un mecanismo para realizar busquedas en el repositorio de datos mediante Linq
        /// </summary>
        /// <param name="predicate">Query en Linq</param>
        /// <returns></returns>
        public IList<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            var matchFunction = predicate.Compile();
            return Entities.Cast<T>().Where(matchFunction).ToList<T>();
        }


        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        public void Update(T entity)
        {
            entity.ThrowIfNull<T>("No se pueden actualizar elementos nulos");
            var idProperty = GetIdProperty();
            int id = Int32.Parse(idProperty.GetValue(entity).ToString());
            Delete(id);
            Add(entity);
        }

        /// <summary>
        /// Libera el repositorio
        /// </summary>
        public void Release()
        {
            Entities.Clear();
        }

        /// <summary>
        /// Guarda los cambios en el repositorio
        /// </summary>
        public void Save()
        {
            // No es necesario
        }


        private static PropertyInfo GetIdProperty()
        {
            return typeof(T).GetProperty("id", BindingFlags.SetProperty | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}


