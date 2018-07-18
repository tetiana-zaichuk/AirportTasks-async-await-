using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using FakeItEasy;
using NUnit.Framework;
using DTO = Shared.DTO;

namespace Airport.Tests.Services
{/*
    [TestFixture]
    public class FlightServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<Flight> _fakeFlightRepository;
        private readonly IRepository<Ticket> _fakeTicketRepository;
        private readonly IMapper _fakeMapper;
        private FlightService _flightService;
        private int _flightId;
        private Flight _flight;
        private DTO.Flight _flightDTO;

        public FlightServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakeFlightRepository = A.Fake<IRepository<Flight>>();
            _fakeTicketRepository = A.Fake<IRepository<Ticket>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _flightId = 1;
            _flight = new Flight()
            {
                Id = _flightId, DepartureId = 1, Departure = "Kiev", DepartureTime = new DateTime(2018, 7, 15, 19, 35, 00), Destination = "Tbilisi",
                ArrivalTime = new DateTime(2018, 7, 15, 21, 52, 00), Tickets = new List<Ticket> { new Ticket() { Id = 1, Price = 5000 } }
            };

            _flightDTO = new DTO.Flight()
            {
                Id = _flightId, Departure = "Kiev", DepartureTime = new DateTime(2018, 7, 15, 19, 35, 00), Destination = "Tbilisi",
                ArrivalTime = new DateTime(2018, 7, 15, 21, 52, 00), Tickets = new List<DTO.Ticket> { new DTO.Ticket() { Id = 1, Price = 5000 } }   
             };

            A.CallTo(() => _fakeMapper.Map<Flight, DTO.Flight>(_flight)).Returns(_flightDTO);
            A.CallTo(() => _fakeMapper.Map<DTO.Flight, Flight>(_flightDTO)).Returns(_flight);

            A.CallTo(() => _fakeUnitOfWork.FlightRepository).Returns(_fakeFlightRepository);
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>()).Returns(_fakeTicketRepository);
            _flightService = new FlightService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_ListTicketsExist()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().GetAsync(_flightId)).Returns(new List<Ticket> { _flight.Tickets.First() });
            var result = _flightService.ValidationForeignIdAsync(_flightDTO);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_ListTicketsDoesntExist()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().GetAsync(_flightId)).Returns(new List<Ticket>{});
            var result = _flightService.ValidationForeignIdAsync(_flightDTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsExists_ShouldReturnFlightDto_WhenFlightExists()
        {
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(_flightId)).Returns(new List<Flight> { _flight });
            var result = _flightService.IsExistAsync(_flightId);
            Assert.AreEqual(_flightDTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.Flight, Flight>(_flightDTO)).Returns(_flight);
            var result = _flightService.ConvertToModel(_flightDTO);
            Assert.AreEqual(_flight, result);
        }

        [Test]
        public void GetAll_Should_ReturnListFlightsDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<Flight>, List<DTO.Flight>>(A<List<Flight>>.That.Contains(_flight)))
                .Returns(new List<DTO.Flight> { _flightDTO });
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> { _flight });
            List<DTO.Flight> result = _flightService.GetAllAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.Flight> { _flightDTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnFlightDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(_flightId)).Returns(new List<Flight> { _flight });
            var result = _flightService.GetDetailsAsync(_flightId);
            Assert.AreEqual(_flightDTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _flightService.AddAsync(_flightDTO);
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.CreateAsync(_flight, null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _flightService.UpdateAsync(_flightDTO);
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.Update(_flight, null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _flightService.RemoveAsync(_flightId);
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.Delete(_flightId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _flightService.RemoveAllAsync();
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.Delete(null)).MustHaveHappenedOnceExactly();
        }
    }*/
}
