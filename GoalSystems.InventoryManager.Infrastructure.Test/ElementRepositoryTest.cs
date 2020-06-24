using System;
using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Infrastructure.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace GoalSystems.InventoryManager.Infrastructure.Test
{
    /// <summary>
    /// Pruebas unitarias del repositio de elementos
    /// </summary>
    [TestClass]
    public class ElementRepositoryTest
    {
        private static IElementRepository Repository;
        [ClassInitialize()]
        public static void InitTestSuite(TestContext testContext)
        {
            var services = new ServiceCollection();
            Services.RegistrationService.AddRepositories(services);
            Repository = services.BuildServiceProvider().GetService<IElementRepository>();
        }

        [TestMethod]
        public void AddTest()
        {
            Element e = DummyData.NewElement();
            Element aux = Repository.Add(e);
            Assert.IsNotNull(aux);
            Assert.IsTrue(e == aux);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTest2()
        {
            Repository.Add(null);            
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Element e = Repository.GetById(1);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void GetByNameTest()
        {
            Element e = Repository.GetQuery(c => c.Name.Contains("1")).FirstOrDefault();
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void GetAll()
        {
            IList<Element> elements = Repository.GetAll();
            Assert.IsNotNull(elements);
            Assert.IsTrue(elements.Count > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Creamos un elemento antes de borrarlo para asegurarnos que existe
            Element e = DummyData.NewElement();
            Repository.Add(e);
            Repository.Delete(e.Id);            
        }

    }
}
