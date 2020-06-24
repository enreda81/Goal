using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Infrastructure.Test;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalSystems.InventoryManager.Domain.Services.Test
{
    /// <summary>
    /// Pruebas unitarias del servicio de dominio InventoryService
    /// </summary>
    [TestClass]
    public class InventoryServiceTest
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
        public void AddTest()
        {
            using (Service)
            {
                Element e = Service.AddElement(DummyData.NewElement());
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTest2()
        {
            using (Service)
            {
                Element e = Service.AddElement(null);
                Assert.IsNotNull(e);
            }
        }


        [TestMethod]
        public void GetElementByNameTest()
        {
            using (Service)
            {
                Element e = Service.GetElementByName("Elemento 1");
                Assert.IsNotNull(e);
            }
        }


        [TestMethod]
        public void GetAll()
        {
            using (Service)
            {
                IEnumerable<Element> elements = Service.GetAll();
                Assert.IsNotNull(elements);
                Assert.IsTrue(elements.Any());
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (Service)
            {
                // Creamos un elemento antes de borrarlo para asegurarnos que existe
                Element e = DummyData.NewElement();
                Service.AddElement(e);
                Service.RemoveElement(e);
            }
        }

    }
}
