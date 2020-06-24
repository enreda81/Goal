using GoalSystems.InventoryManager.Domain.Entities;

namespace GoalSystems.InventoryManager.Api.Model.Auth
{
    /// <summary>
    /// Servicio para comprobar las credenciales de un usuario
    /// </summary>
    public interface IUserAuthenticationService
    {
        /// <summary>
        /// Indica si el usuario tiene acceso
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsValidUser(User user);
    }
}
