using System;
using System.Collections.Generic;

namespace GoalSystems.InventoryManager.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Clase abstracta y no genérica utilizada para tener una única instancia de la variable estática independientemente del tipo
    /// Esto nos permite simular un único medio de persistencia con diferentes tipos, como si fuera una BD
    /// </summary>
    internal abstract class NonGenericFakeBaseRepository
    {
        /// <summary>
        /// Constructor protected
        /// </summary>
        protected NonGenericFakeBaseRepository() { }

        /// <summary>
        /// Constructor estático, en el que inicializamos el contexto unicamente en la primera instancia
        /// </summary>
        static NonGenericFakeBaseRepository()
        {
            Context = new Dictionary<Type, List<Object>>();
        }

        /// <summary>
        /// Variable estática donde persistimos el contexto en memoria
        /// </summary>
        internal static Dictionary<Type, List<Object>> Context { get; set; }

    }
}
