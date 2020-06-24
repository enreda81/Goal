using System;

namespace GoalSystems.InventoryManager.Domain.Entities
{
    /// <summary>
    /// Identifica a un usuario de la aplicación
    /// </summary>
    public class User
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Contraseña
        /// </summary>
        public String Password { get; set; }
    }
}
