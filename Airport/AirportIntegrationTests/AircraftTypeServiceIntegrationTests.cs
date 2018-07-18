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
    public class AircraftTypeServiceIntegrationTests
    {
        private readonly TestServer _server;
        private UnitOfWork uow;
        private AircraftTypeService _aircraftTypeService;
        private AirportContext airportContext;
        private DTO.AircraftType _type;

        public AircraftTypeServiceIntegrationTests()
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
                cfg.CreateMap<AircraftType, DTO.AircraftType>();
                cfg.CreateMap<DTO.AircraftType, AircraftType>();
            });

            return config;
        }

        [SetUp]
        public void TestSetup()
        {
            _type = new DTO.AircraftType() { AircraftModel = "Tupolev Tu-134444", SeatsNumber = 80, Carrying = 47000 };

            uow= new UnitOfWork(airportContext);
            var mapper = GetAutoMapperConfig().CreateMapper();
            _aircraftTypeService = new AircraftTypeService(uow, mapper);
        }

        [Test]
        public void GetDetails_Should_ReturnAircraftType_When_Called()
        {
            var type = _aircraftTypeService.GetAllAsync().First();
            var result = _aircraftTypeService.GetDetailsAsync(type.Id);
            Assert.AreEqual(type.Id, result.Id);
        }

        [Test]
        public void GetAll_Should_ReturnListAircraftsTypes_When_Called()
        {
            List<DTO.AircraftType> result = _aircraftTypeService.GetAllAsync();
            Assert.GreaterOrEqual(result.Count, 3);
        }

        [Test]
        public void Add_Should_StoreAircraftTypeInDatabase_When_Called()
        {
            var oldCount = _aircraftTypeService.GetAllAsync().Count;
            _aircraftTypeService.AddAsync(_type);
            var newCount = _aircraftTypeService.GetAllAsync().Count;
            Assert.Greater(newCount,oldCount);
        }


        [Test]
        public void Update_Should_UpdateAircraftTypeInDatabase_When_Called()
        {
            var type = _aircraftTypeService.GetAllAsync().First();
            var oldName = type.AircraftModel;
            type.AircraftModel = "New Model";

            _aircraftTypeService.UpdateAsync(type);
            Assert.AreNotEqual(type.AircraftModel, oldName);
        }

        [Test]
        public void Remove_Should_DeleteAircraftTypeFromDatabase_When_Called()
        {
            var oldCount = _aircraftTypeService.GetAllAsync().Count;
            var type = _aircraftTypeService.GetAllAsync().First();
            _aircraftTypeService.RemoveAsync(type.Id);
            var newCount = _aircraftTypeService.GetAllAsync().Count;
            Assert.Greater(oldCount, newCount);
        }
    }*/
}
