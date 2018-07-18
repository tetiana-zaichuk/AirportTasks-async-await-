using System;
using System.Collections.Generic;
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
    public class DepartureServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<Departure> _fakeDepartureRepository;
        private readonly IRepository<Aircraft> _fakeAircraftRepository;
        private readonly IRepository<Flight> _fakeFlightRepository;
        private readonly IRepository<Crew> _fakeCrewRepository;
        private readonly IMapper _fakeMapper;
        private DepartureService _departureService;
        private int _departureId;
        private static Departure _departure;
        private DTO.Departure _departureDTO;

        public DepartureServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakeDepartureRepository = A.Fake<IRepository<Departure>>();
            _fakeAircraftRepository = A.Fake<IRepository<Aircraft>>();
            _fakeFlightRepository = A.Fake<IRepository<Flight>>();
            _fakeCrewRepository = A.Fake<IRepository<Crew>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _departureId = 1;
            _departure = new Departure()
            {
                Id = _departureId, DepartureDate = new DateTime(2018, 7, 15, 19, 35, 00),
                Flight = new Flight()
                {
                    Id = 1, DepartureId = 1, Departure = "Kiev", DepartureTime = new DateTime(2018, 7, 15, 19, 35, 00),
                    Destination = "Tbilisi", ArrivalTime = new DateTime(2018, 7, 15, 21, 52, 00),
                    Tickets = new List<Ticket> { new Ticket() { Price = 5000 } }
                },
                Aircraft = new Aircraft()
                {
                    Id = 1, AircraftName = "Strong",
                    AircraftType = new AircraftType() { AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 },
                    AircraftReleaseDate = new DateTime(2011, 6, 10),
                    ExploitationTimeSpan = new DateTime(2021, 6, 10) - new DateTime(2011, 6, 10)
                },
                Crew = new Crew()
                {
                    Id = 1, Pilot = new Pilot() { FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978, 03, 03), Experience = 9 },
                    Stewardesses = new List<Stewardess> { new Stewardess() { CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993, 02, 03) } },
                }
            };

            _departureDTO = new DTO.Departure()
            {
                Id = _departureId, DepartureDate = new DateTime(2018, 7, 15, 19, 35, 00),
                Flight = new DTO.Flight()
                {
                    Id = 1, Departure = "Kiev", DepartureTime = new DateTime(2018, 7, 15, 19, 35, 00), Destination = "Tbilisi",
                    ArrivalTime = new DateTime(2018, 7, 15, 21, 52, 00), Tickets = new List<DTO.Ticket> { new DTO.Ticket() { Price = 5000 } }
                },
                Aircraft = new DTO.Aircraft()
                {
                    Id = 1, AircraftName = "Strong",
                    AircraftType = new DTO.AircraftType() { AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 },
                    AircraftReleaseDate = new DateTime(2011, 6, 10), ExploitationTimeSpan = new DateTime(2021, 6, 10) - new DateTime(2011, 6, 10)
                },
                Crew = new DTO.Crew()
                {
                    Id = 1, Pilot = new DTO.Pilot() { FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978, 03, 03), Experience = 9 },
                    Stewardesses = new List<DTO.Stewardess> { new DTO.Stewardess() { CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993, 02, 03) } },
                }
            };

            A.CallTo(() => _fakeMapper.Map<Departure, DTO.Departure>(_departure)).Returns(_departureDTO);
            A.CallTo(() => _fakeMapper.Map<DTO.Departure, Departure>(_departureDTO)).Returns(_departure);

            A.CallTo(() => _fakeUnitOfWork.DepartureRepository).Returns(_fakeDepartureRepository);
            A.CallTo(() => _fakeUnitOfWork.AircraftRepository).Returns(_fakeAircraftRepository);
            A.CallTo(() => _fakeUnitOfWork.FlightRepository).Returns(_fakeFlightRepository);
            A.CallTo(() => _fakeUnitOfWork.CrewRepository).Returns(_fakeCrewRepository);
            _departureService = new DepartureService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() {}

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_AircraftFlightCrewExist()
        {
            A.CallTo(() => _fakeUnitOfWork.AircraftRepository.GetAsync(null)).Returns(new List<Aircraft> { _departure.Aircraft });
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> { _departure.Flight });
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(null)).Returns(new List<Crew> { _departure.Crew });
            var result = _departureService.ValidationForeignIdAsync(_departureDTO);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_AircraftDoesntExistFlightCrewExist()
        {
            A.CallTo(() => _fakeUnitOfWork.AircraftRepository.GetAsync(null)).Returns(new List<Aircraft> { });
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> { _departure.Flight });
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(null)).Returns(new List<Crew> { _departure.Crew });
            var result = _departureService.ValidationForeignIdAsync(_departureDTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_FlightDoesntExistAircraftCrewExist()
        {
            A.CallTo(() => _fakeUnitOfWork.AircraftRepository.GetAsync(null)).Returns(new List<Aircraft> { _departure.Aircraft });
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> { });
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(null)).Returns(new List<Crew> { _departure.Crew });
            var result = _departureService.ValidationForeignIdAsync(_departureDTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_CrewDoesntExistAircrafFlighttExist()
        {
            A.CallTo(() => _fakeUnitOfWork.AircraftRepository.GetAsync(null)).Returns(new List<Aircraft> { _departure.Aircraft });
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> { _departure.Flight });
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(null)).Returns(new List<Crew> { });
            var result = _departureService.ValidationForeignIdAsync(_departureDTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsExists_ShouldReturnDepartureDto_When_DepartureExists()
        {
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.GetAsync(_departureId)).Returns(new List<Departure> { _departure });
            var result = _departureService.IsExistAsync(_departureId);
            Assert.AreEqual(_departureDTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.Departure, Departure>(_departureDTO)).Returns(_departure);
            var result = _departureService.ConvertToModel(_departureDTO);
            Assert.AreEqual(_departure, result);
        }

        [Test]
        public void GetAll_Should_ReturnListDepartureDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<Departure>, List<DTO.Departure>>(A<List<Departure>>.That.Contains(_departure)))
                .Returns(new List<DTO.Departure> { _departureDTO });
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.GetAsync(null)).Returns(new List<Departure> { _departure });
            List<DTO.Departure> result = _departureService.GetAllAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.Departure> { _departureDTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnDepartureDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.GetAsync(_departureId)).Returns(new List<Departure> { _departure });
            var result = _departureService.GetDetailsAsync(_departureId);
            Assert.AreEqual(_departureDTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _departureService.AddAsync(_departureDTO);
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.CreateAsync(_departure, null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _departureService.UpdateAsync(_departureDTO);
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.Update(_departure, null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _departureService.RemoveAsync(_departureId);
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.Delete(_departureId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _departureService.RemoveAllAsync();
            A.CallTo(() => _fakeUnitOfWork.DepartureRepository.Delete(null)).MustHaveHappenedOnceExactly();
        }
    }*/
}
