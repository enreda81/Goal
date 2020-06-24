using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Infrastructure.CrossCutting.ExtensionMethod;
using GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Logging;
using GoalSystems.InventoryManager.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GoalSystems.InventoryManager.Domain.Services
{
    /// <summary>
    /// Servicio de dominio que representa un inventario de elementos
    /// </summary>
    internal class InventoryService : ServiceBase, IInventoryService
    {
        #region Private Fields

        private readonly IElementRepository ElementRepository;
        private bool disposed;

        #endregion Private Fields


        #region Events
        
        /// <summary>
        /// Evento disparado cada vez que un elemento ha expirado
        /// </summary>
        public event Notify ElementExpired;

        /// <summary>
        /// Evento disparado cada vez que un elemento ha sido eliminado del inventario
        /// </summary>
        public event Notify ElementRemoved;
        
        #endregion


        #region Constructor

        /// <summary>
        /// Constructor público
        /// </summary>
        public InventoryService(IElementRepository r)
        {
            ElementRepository = r;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Agrega un elemento al inventario
        /// </summary>
        /// <param name="e">Elemento</param>
        /// <returns></returns>
        public Element AddElement(Element e)
        {
            e.ThrowIfNull("No se pueden agregar entidades nulas");
            e.Id.ThrowIfLessThan(0);
            e.Name.ThrowIfNullorEmpty("Name");

            if (e.IsExpired())
                OnElementExpired(e);

            if (ElementRepository.GetQuery(c => c.Id == e.Id).Any())
                throw new ValidationException("Ya existe un elemento con el mismo identificador");

            return ElementRepository.Add(e);
        }

        /// <summary>
        /// Obtiene un elemento del inventario a partir de su nombre
        /// </summary>
        /// <param name="name">Nombre del elemento</param>
        /// <returns></returns>
        public Element GetElementByName(string name)
        {
            name.ThrowIfNullorEmpty(nameof(name));
            Element e = ElementRepository.GetQuery(c => c.Name.Contains(name)).FirstOrDefault();

            if (e == null)
                throw new ValidationException("El elemento no existe");

            if (e.IsExpired())
                OnElementExpired(e);

            return e;
        }

        /// <summary>
        /// Elimina un elemento del inventario
        /// </summary>
        /// <param name="e">Elemento</param>
        public void RemoveElement(Element e)
        {            
            if (e != null)
            {
                ElementRepository.Delete(e);
                OnElementRemoved(e);
            }
        }

        /// <summary>
        /// Elimina un elemento del inventario
        /// </summary>
        /// <param name="name">Nombre del elemento</param>
        public void RemoveElement(string name)
        {
            name.ThrowIfNullorEmpty(nameof(name));
            Element e = GetElementByName(name);
            RemoveElement(e);
        }

        /// <summary>
        /// Proporciona la colección de todos los elementos del inventario
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Element> GetAll()
        {
            IEnumerable<Element> elements = ElementRepository.GetAll();
            elements?.Where(c => c.IsExpired()).ToList().ForEach(i => OnElementExpired(i));
            return elements;
        }


        #endregion


        #region Private Event Managers

        /// <summary>
        /// Manejador del evento de elementos expirados
        /// </summary>
        private void OnElementExpired(Element element)
        {
            ElementExpired?.Invoke(element);
        }

        /// <summary>
        /// Manejador del evento de elementos eliminados
        /// </summary>
        private void OnElementRemoved(Element element)
        {
            ElementRemoved?.Invoke(element);
        }

        #endregion

        #region Idisposable Members

        /// <summary>
        /// Implementa el método Dispose de la interfaz IDisposable para eliminar los elementos no manejados del servicio de dominio
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            // No es necesario, en una implementación contra BD por ejemplo sería necesario liberar los recursos, guardar los elementos no guardados y cerrar la conexión a la BD
            //ElementRepository?.Release();

            disposed = true;            
        }

        #endregion        

    }
}
