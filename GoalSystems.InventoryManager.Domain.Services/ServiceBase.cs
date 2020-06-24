using System;

namespace GoalSystems.InventoryManager.Domain.Services
{
    /// <summary>
    /// Servicio de dominio base
    /// </summary>
    internal abstract class ServiceBase : IServiceBase
    {
        #region Private Destructor
        
        /// <summary>
        /// Destructor
        /// </summary>
        ~ServiceBase()
        {
            Dispose(false);
        }

        #endregion Private Destructors

        #region Public Methods

        /// <summary>
        /// Liberación o restablecimiento de recursos no administrados.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Liberación implícita
        /// </summary>
        /// <param name="disposing"></param>
        protected abstract void Dispose(bool disposing);

        #endregion Public Methods
    }
}
