using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using PresentationLayer;
using Shared.DTO;

namespace AirportFunctional.Tests
{
    public class AircraftTypeTests
    {
        //private AirportContext _airportContext;
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private const string Path = "http://localhost:38236/api/";
        private int _aircraftTypeId;
        private AircraftType _type;

        public AircraftTypeTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [SetUp]
        public void TestSetup()
        {
            _aircraftTypeId = 1;
            _type = new AircraftType()
            {
                AircraftModel = "Tupolev Tu-1344444", SeatsNumber = 80, Carrying = 47000
            };
        }

        [TearDown]
        public void TestTearDown() { }

        [Test]
        public async Task TestGetAircraftsTypes()
        {
            var response = await _client.GetAsync(Path + "AircraftsTypes/");
            response.EnsureSuccessStatusCode();
            var responseString =  response.Content.ReadAsStringAsync().Result;
            var result=JsonConvert.DeserializeObject<List<AircraftType>>(responseString);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public async Task TestGetById()
        {
            var response = await _client.GetAsync(Path + "AircraftsTypes/5");
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AircraftType>(responseString);
            
            _type.Id = 5;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(_type.Id, result.Id);
                Assert.AreEqual(_type.AircraftModel, result.AircraftModel);
                Assert.AreEqual(_type.SeatsNumber, result.SeatsNumber);
            });
        }
        
        [Test]
        public async Task TestPostAircraftType()
        {
            string json = await Task.Run(() => JsonConvert.SerializeObject(_type));
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(Path + "AircraftsTypes/", httpContent);
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AircraftType>(responseString);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(_type.AircraftModel, result.AircraftModel);
                Assert.AreEqual(_type.SeatsNumber, result.SeatsNumber);
            });
        }
        
        [Test]
        public async Task TestDeleteById()
        {
            var response = await _client.DeleteAsync(Path + "AircraftsTypes/11");
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
       
    }
}
