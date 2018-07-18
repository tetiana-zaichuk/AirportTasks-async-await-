using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PresentationLayer;
using DTO=Shared.DTO;

namespace AirportIntegration.Tests
{/*
    public class AircraftServiceIntegrationTests
    {
        private readonly TestServer _server;
        private UnitOfWork uow;
        private AircraftService _aircraftService;
        private AirportContext airportContext;
        private DTO.Aircraft _plane;

        public AircraftServiceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<AirportContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Airportdb;Trusted_Connection=True;")
                .EnableSensitiveDataLogging()
                .Options;
            airportContext = new AirportContext(options);
            
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        private MapperConfiguration GetAutoMapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aircraft, Shared.DTO.Aircraft>();
                cfg.CreateMap<Shared.DTO.Aircraft, Aircraft>();
                cfg.CreateMap<AircraftType, Shared.DTO.AircraftType>();
                cfg.CreateMap<Shared.DTO.AircraftType, AircraftType>();
                cfg.CreateMap<Flight, Shared.DTO.Flight>();
                cfg.CreateMap<Shared.DTO.Flight, Flight>();
                cfg.CreateMap<Pilot, Shared.DTO.Pilot>();
                cfg.CreateMap<Shared.DTO.Pilot, Pilot>().ForMember(p => p.Crew, opt => opt.Ignore());
                cfg.CreateMap<Shared.DTO.Crew, Crew>();
            });

            return config;
        }

        [SetUp]
        public void TestSetup()
        {
            _plane = new DTO.Aircraft()
            {
                AircraftName = "StrongWind",
                AircraftType = new DTO.AircraftType() { AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 },
                AircraftReleaseDate = new DateTime(2011, 6, 10),
                ExploitationTimeSpan = new DateTime(2021, 6, 10) - new DateTime(2011, 6, 10)
            };

            uow= new UnitOfWork(airportContext);
            var mapper = GetAutoMapperConfig().CreateMapper();
            _aircraftService = new AircraftService(uow, mapper);
        }

        [Test]
        public void GetDetails_Should_ReturnAircraft_When_Called()
        {
            var plane = _aircraftService.GetAllAsync().First();
            var result = _aircraftService.GetDetails(plane.Id);
            Assert.AreEqual(plane.Id, result.Id);
        }

        [Test]
        public void GetAll_Should_ReturnListAircrafts_When_Called()
        {
            List<DTO.Aircraft> result = _aircraftService.GetAllAsync();
            Assert.GreaterOrEqual(result.Count, 3);
        }

        [Test]
        public void Add_Should_StoreAircraftInDatabase_When_Called()
        {
            var oldCount = _aircraftService.GetAllAsync().Count;
            _aircraftService.AddAsync(_plane);
            var newCount = _aircraftService.GetAllAsync().Count;
            Assert.Greater(newCount,oldCount);
        }


        [Test]
        public void Update_Should_UpdateAircraftInDatabase_When_Called()
        {
            var plane = _aircraftService.GetAllAsync().First();
            var oldName = plane.AircraftName;
            plane.AircraftName = "New Name";

            _aircraftService.UpdateAsync(plane);
            Assert.AreNotEqual(plane.AircraftName, oldName);
        }

        [Test]
        public void Remove_Should_DeleteAircraftFromDatabase_When_Called()
        {
            var oldCount = _aircraftService.GetAllAsync().Count;
            var plane=_aircraftService.GetAllAsync().First();
            _aircraftService.RemoveAsync(plane.Id);
            var newCount = _aircraftService.GetAllAsync().Count;
            Assert.Greater(oldCount, newCount);
        }
    }*/
}
