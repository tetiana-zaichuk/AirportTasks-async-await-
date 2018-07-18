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
    public class TicketServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<Ticket> _fakeTicketRepository;
        private readonly IMapper _fakeMapper;
        private TicketService _ticketService;
        private int _ticketId;
        private Ticket _ticket;
        private DTO.Ticket _ticketDTO;

        public TicketServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakeTicketRepository = A.Fake<IRepository<Ticket>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _ticketId = 1;
            _ticket = new Ticket()
            {
                Id = _ticketId, FlightId = 1, Price = 5000,
                Flight = new Flight(){ Id = 1, DepartureId = 1, Departure = "Kiev", DepartureTime = new DateTime(2018,7,15,19,35,00), Destination = "Tbilisi",
                ArrivalTime = new DateTime(2018,7,15,21,52,00), Tickets = new List<Ticket>{}}

            };
            _ticketDTO = new DTO.Ticket()
            {
                Id = _ticketId, FlightId = 1, Price = 5000,
                Flight = new DTO.Flight(){ Id = 1, Departure = "Kiev", DepartureTime = new DateTime(2018,7,15,19,35,00), Destination = "Tbilisi",
                ArrivalTime = new DateTime(2018,7,15,21,52,00), Tickets = new List<DTO.Ticket>{}}
            };

            A.CallTo(() => _fakeMapper.Map<Ticket, DTO.Ticket>(_ticket)).Returns(_ticketDTO);
            A.CallTo(() => _fakeMapper.Map<DTO.Ticket, Ticket>(_ticketDTO)).Returns(_ticket);

            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>()).Returns(_fakeTicketRepository);
            _ticketService = new TicketService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_FlightExists()
        {
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> { _ticket.Flight });
            var result = _ticketService.ValidationForeignIdAsync(_ticketDTO);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_FlightDoenstExist()
        {
            A.CallTo(() => _fakeUnitOfWork.FlightRepository.GetAsync(null)).Returns(new List<Flight> {});
            var result = _ticketService.ValidationForeignIdAsync(_ticketDTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsExists_ShouldReturnTicketDto_When_TicketExists()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().GetAsync(_ticketId)).Returns(new List<Ticket> { _ticket });
            var result = _ticketService.IsExistAsync(_ticketId);
            Assert.AreEqual(_ticketDTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.Ticket, Ticket>(_ticketDTO)).Returns(_ticket);
            var result = _ticketService.ConvertToModel(_ticketDTO);
            Assert.AreEqual(_ticket, result);
        }

        [Test]
        public void GetAll_Should_ReturnListTicketsDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<Ticket>, List<DTO.Ticket>>(A<List<Ticket>>.That.Contains(_ticket)))
                .Returns(new List<DTO.Ticket> { _ticketDTO });
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().GetAsync(null)).Returns(new List<Ticket> { _ticket });
            List<DTO.Ticket> result = _ticketService.GetAllAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.Ticket> { _ticketDTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnTicketDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().GetAsync(_ticketId)).Returns(new List<Ticket> { _ticket });
            var result = _ticketService.GetDetailsAsync(_ticketId);
            Assert.AreEqual(_ticketDTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _ticketService.AddAsync(_ticketDTO);
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().CreateAsync(A<Ticket>.That.IsInstanceOf(typeof(Ticket)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _ticketService.UpdateAsync(_ticketDTO);
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().Update(A<Ticket>.That.IsInstanceOf(typeof(Ticket)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _ticketService.RemoveAsync(_ticketId);
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().Delete(_ticketId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _ticketService.RemoveAllAsync();
            A.CallTo(() => _fakeUnitOfWork.Set<Ticket>().Delete(null)).MustHaveHappenedOnceExactly();
        }
    }*/
}
