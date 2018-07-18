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
    public class AircraftTests
    {
        //private AirportContext _airportContext;
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private const string Path = "http://localhost:38236/api/";
        private int _aircraftId;
        private Aircraft _plane;

        public AircraftTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();          
        }

        [SetUp]
        public void TestSetup()
        {
            _aircraftId = 1;
            _plane = new Aircraft()
            {
                AircraftName = "Strong",
                AircraftType = new AircraftType() { Id = 5, AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 },
                AircraftReleaseDate = new DateTime(2011, 6, 10),
                ExploitationTimeSpan = new DateTime(2021, 6, 10) - new DateTime(2011, 6, 10)
            };
            
        }

        [TearDown]
        public void TestTearDown() { }

        [Test]
        public async Task TestGetAircraft()
        {
            var response = await _client.GetAsync(Path + "Aircrafts/");
            response.EnsureSuccessStatusCode();
            var responseString =  response.Content.ReadAsStringAsync().Result;
            var result=JsonConvert.DeserializeObject<List<Aircraft>>(responseString);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public async Task TestGetById()
        {
            var response = await _client.GetAsync(Path + "Aircrafts/9");
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Aircraft>(responseString);
            
            _plane.Id = 9;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(_plane.Id, result.Id);
                Assert.AreEqual(_plane.AircraftReleaseDate, result.AircraftReleaseDate);
                Assert.AreEqual(_plane.ExploitationTimeSpan, result.ExploitationTimeSpan);
            });
        }
        
        [Test]
        public async Task TestUpdateAircraft()
        {
            string json = await Task.Run(() => JsonConvert.SerializeObject(_plane));
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(Path + "Aircrafts/9", httpContent);
            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Aircraft>(responseString);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(_plane.AircraftReleaseDate, result.AircraftReleaseDate);
                Assert.AreEqual(_plane.ExploitationTimeSpan, result.ExploitationTimeSpan);
            });
        }

        [Test]
        public async Task TestDeleteById()
        {
            var response = await _client.DeleteAsync(Path + "Aircrafts/9");
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task TestDeleteAircrafts()
        {
            var response = await _client.DeleteAsync(Path + "Aircrafts/");
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
