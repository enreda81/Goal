using GoalSystems.InventoryManager.Domain.Entities;
using System;
using System.Linq;

namespace GoalSystems.InventoryManager.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Repositorio de la entidad Element
    /// </summary>
    internal class ElementRepository : MemoryBaseRepository<Element>, IElementRepository
    {
        /// <summary>
        /// Constructor público
        /// </summary>
        public ElementRepository() : base()
        {
            // Código de pruebas para agregar datos al repositorio que persiste en memoria
            // No subir a producción
            if (!Entities.Any())
                AddDummyElements();
        }
        #region Private Methods

        /// <summary>
        /// Método con código de pruebas para que haya datos de prueba
        /// Eliminar en un entorno de producción
        /// </summary>
        private void AddDummyElements()
        {
            Entities.Add(
                new Element()
                {
                    Id = 0,
                    Name = "Elemento 1",
                    ExpirationDate = DateTime.UtcNow.AddDays(1),
                    Type = ElementType.Type1
                }
                );
            Entities.Add(
                new Element()
                {
                    Id = 1,
                    Name = "Elemento 2",
                    ExpirationDate = DateTime.UtcNow.AddDays(1),
                    Type = ElementType.Type2
                }
                );
            Entities.Add(
                new Element()
                {
                    Id = 2,
                    Name = "Elemento 3",
                    ExpirationDate = DateTime.UtcNow.AddDays(1),
                    Type = ElementType.Type3
                }
                );
        }

        #endregion
    }
}
