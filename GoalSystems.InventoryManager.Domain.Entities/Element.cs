using System;

namespace GoalSystems.InventoryManager.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un elemento del inventario
    /// </summary>
    public class Element
    {
        /// <summary>
        /// Identificador del elemento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del elemento
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Fecha de expiración del elemento
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Tipo de elemento
        /// </summary>
        public ElementType Type { get; set; }

        /// <summary>
        /// Indica si el elemento ha expirado
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return ExpirationDate < DateTime.UtcNow;
        }
    }
}
