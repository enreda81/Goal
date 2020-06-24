using GoalSystems.InventoryManager.Domain.Entities;

namespace GoalSystems.InventoryManager.Domain.Services
{
    /// <summary>
    /// Delegado que representa la firma que debe de implementar un manejador de notificaciones
    /// </summary>
    /// <param name="element"></param>
    public delegate void Notify(Element element);
}
