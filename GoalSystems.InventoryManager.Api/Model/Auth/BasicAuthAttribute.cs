using Microsoft.AspNetCore.Mvc;
using System;

namespace GoalSystems.InventoryManager.Api.Model.Auth
{
    /// <summary>
    /// Atributo para implementar seguridad básica en cada método del API
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute(string realm = @"GoalSystems Inventory Management") : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }    
}
