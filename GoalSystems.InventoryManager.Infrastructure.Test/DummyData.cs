using GoalSystems.InventoryManager.Domain.Entities;
using System;

namespace GoalSystems.InventoryManager.Infrastructure.Test
{
    /// <summary>
    /// Clase de pruebas para generar de forma aleatorio objetos de tipo Element
    /// </summary>
    public static class DummyData
    {
        private static int NewRandomId()
        {
            Random rnd = new Random();
            return rnd.Next(5, Int32.MaxValue);
        }

        public static Element NewElement()
        {
            return new Element()
            {
                Id = NewRandomId(),
                ExpirationDate = DateTime.UtcNow,
                Name = Guid.NewGuid().ToString(),
                Type = ElementType.Type1
            };
        }
    }
}
