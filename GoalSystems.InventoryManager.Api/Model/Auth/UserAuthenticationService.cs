using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Security;

namespace GoalSystems.InventoryManager.Api.Model.Auth
{
    /// <summary>
    /// Servicio para comprobar las credenciales de un usuario
    /// </summary>
    public class UserAuthenticationService : IUserAuthenticationService
    {
        /// <summary>
        /// Indica si el usuario tiene acceso
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidUser(User user)
        {
            return SecurityService.IsUserValid(user);
        }
    }
}
