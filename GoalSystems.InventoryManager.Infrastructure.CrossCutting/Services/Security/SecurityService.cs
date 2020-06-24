using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Infrastructure.CrossCutting.ExtensionMethod;
using System;

namespace GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Security
{
    /// <summary>
    /// Servicio cross de seguridad
    /// </summary>
    public static class SecurityService
    {
        // Las credenciales las dejamos aquí hardcodeadas para la demo
        private const String Username = "goalsystems";
        private const String Password = "12345";

        public static bool IsUserValid(User user)
        {
            user.ThrowIfNull("Acceso denegado");
            return user.Name.ToLower() == Username && user.Password.ToLower() == Password;
        }
    }
}
