using GoalSystems.InventoryManager.Domain.Entities;
using GoalSystems.InventoryManager.Infrastructure.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoalSystems.InventoryManager.Api.Test
{
    /// <summary>
    /// Pruebas unitarias del API
    /// </summary>
    [TestClass]
    public class ApiHttpTest
    {
        private const string ApiUri = "https://localhost:44369";
        private const String Username = "goalsystems";
        private const String Password = "12345";

        [TestMethod]
        public void GetTest()
        {
            RestClient client = new RestClient(ApiUri);            
            RestRequest request = GetApiRequest($"/api/Inventory", Method.GET);
            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            List<Element> elements = DeserializeJSONFileToObject<List<Element>>(response.Content);

            Assert.IsNotNull(elements);
            Assert.IsTrue(elements.Count > 0);
        }

        [TestMethod]
        [DataRow("Elemento 1")]
        [DataRow("Elemento 2")]
        [DataRow("Elemento 3")]
        public void GetTest2(String name)
        {
            RestClient client = new RestClient(ApiUri);
            RestRequest request = GetApiRequest($"/api/Inventory/{name}", Method.GET);            
            IRestResponse response = client.Execute(request);
            
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            Element e = DeserializeJSONFileToObject<Element>(response.Content);

            Assert.IsNotNull(e);
            Assert.IsTrue(e.Name.Contains(name));
        }


        [TestMethod]
        public void AddTest()
        {
            RestClient client = new RestClient(ApiUri);
            RestRequest request = GetApiRequest($"/api/Inventory", Method.POST);            
            request.AddJsonBody(DummyData.NewElement());
            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Para asegurarnos que el borrado no falle, eliminamos un elemento que creamos previamente
            Element e = DummyData.NewElement();
            RestClient client = new RestClient(ApiUri);
            RestRequest request = GetApiRequest($"/api/Inventory", Method.POST);            
            request.AddJsonBody(e);
            IRestResponse response = client.Execute(request);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            RestRequest deleteRequest = GetApiRequest($"/api/Inventory/{e.Name}", Method.POST);
            response = client.Execute(deleteRequest);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        }
   


        private static T DeserializeJSONFileToObject<T>(string json)
        {
            if (String.IsNullOrEmpty(json))
                return default(T);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        private static RestRequest GetApiRequest(String uri, Method method)
        {
            String userName = Username;
            String passWord = Password;
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
            
            RestRequest request = new RestRequest(uri, method, DataFormat.Json);
            request.AddHeader("Authorization", $"Basic {credentials}");
            return request;
        }
    }
}
