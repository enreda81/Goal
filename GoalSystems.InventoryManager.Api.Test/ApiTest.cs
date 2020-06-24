using GoalSystems.InventoryManager.Api.Controllers;
using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Domain.Services;
using GoalSystems.InventoryManager.Infrastructure.Test;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GoalSystems.InventoryManager.Api.Test
{
    [TestClass]
    public class ApiTest
    {
        private static IInventoryService Service;
        private static IServiceCollection Services;

        [ClassInitialize()]
        public static void InitTestSuite(TestContext testContext)
        {
            Services = new ServiceCollection();
            RegistrationService.AddDomainServices(Services);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Service = Services.BuildServiceProvider().GetService<IInventoryService>();
        }

        [TestMethod]
        public void GetTest()
        {            
            var controller = new InventoryController(Service);
            IEnumerable<Element> elements = controller.Get();
            Assert.IsNotNull(elements);
            Assert.IsTrue(elements.Any());
        }


        [TestMethod]
        [DataRow("Elemento 1")]
        [DataRow("Elemento 2")]
        [DataRow("Elemento 3")]
        public void GetTest2(string name)
        {
            var controller = new InventoryController(Service);
            Element e = controller.Get(name);                       

            Assert.IsNotNull(e);
            Assert.IsTrue(e.Name.Contains(name));
        }


        [TestMethod]
        public void AddTest()
        {
            var controller = new InventoryController(Service);
            controller.Add(DummyData.NewElement());
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Para asegurarnos que el borrado no falle, eliminamos un elemento que creamos previamente
            Element e = DummyData.NewElement();
            var controller = new InventoryController(Service);
            controller.Add(e);

            controller.Delete(e.Name);

        }
    }
}
