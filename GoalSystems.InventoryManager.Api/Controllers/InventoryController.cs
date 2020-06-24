using GoalSystems.InventoryManager.Api.Model.Auth;
using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoalSystems.InventoryManager.Api.Controllers
{
    /// <summary>
    /// Controlador del inventario de elementos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        /// <summary>
        /// Servicio de dominio
        /// </summary>
        private readonly IInventoryService Inventory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public InventoryController(IInventoryService service)
        {
            Inventory = service;
        }

        /// <summary>
        /// Proporciona la lista de todos los elementos del inventario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [BasicAuth]
        public IEnumerable<Element> Get()
        {
            using (Inventory)
            {
                return Inventory.GetAll();
            }
        }


        /// <summary>
        /// Obtiene un elemento del inventario a partir de su nombre
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        [BasicAuth]
        public Element Get(string name)
        {
            using (Inventory)
            {
                return Inventory.GetElementByName(name);
            }
        }


        /// <summary>
        /// Agrega un elemento al inventario
        /// </summary>
        /// <param name="value">Elemento a agregar</param>
        /// <returns></returns>
        [HttpPost]
        [BasicAuth]
        public Element Add(Element value)
        {
            using (Inventory)
            {
                return Inventory.AddElement(value);
            }
        }
        

        /// <summary>
        /// Elimina un elemento del inventario
        /// </summary>
        /// <param name="name">Nombre del elemento</param>
        [HttpPost]
        [BasicAuth]
        [Route("{name}")]
        public void Delete(string name)
        {
            using (Inventory)
            {
                Inventory.RemoveElement(name);
            }
        }
    }
}
