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
    public class PilotServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<Pilot> _fakePilotRepository;
        private readonly IMapper _fakeMapper;
        private PilotService _pilotService;
        private int _pilotId;
        private Pilot _pilot;
        private DTO.Pilot _pilotDTO;

        public PilotServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakePilotRepository = A.Fake<IRepository<Pilot>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _pilotId = 1;
            _pilot = new Pilot() { Id = _pilotId, CrewId = 1, FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978, 03, 03), Experience = 9 };
            _pilotDTO = new DTO.Pilot() { Id = _pilotId, FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978, 03, 03), Experience = 9 };

            A.CallTo(() => _fakeMapper.Map<Pilot, DTO.Pilot>(_pilot)).Returns(_pilotDTO);
            A.CallTo(() => _fakeMapper.Map<DTO.Pilot, Pilot>(_pilotDTO)).Returns(_pilot);

            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>()).Returns(_fakePilotRepository);
            _pilotService = new PilotService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_Always()
        {
            Assert.IsTrue(_pilotService.ValidationForeignIdAsync(_pilotDTO));
        }

        [Test]
        public void IsExists_ShouldReturnPilotDto_WhenPilotExists()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().GetAsync(_pilotId)).Returns(new List<Pilot> { _pilot });
            var result = _pilotService.IsExistAsync(_pilotId);
            Assert.AreEqual(_pilotDTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.Pilot, Pilot>(_pilotDTO)).Returns(_pilot);
            var result = _pilotService.ConvertToModel(_pilotDTO);
            Assert.AreEqual(_pilot, result);
        }

        [Test]
        public void GetAll_Should_ReturnListPilotsDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<Pilot>, List<DTO.Pilot>>(A<List<Pilot>>.That.Contains(_pilot)))
                .Returns(new List<DTO.Pilot> { _pilotDTO });
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().GetAsync(null)).Returns(new List<Pilot> { _pilot });
            List<DTO.Pilot> result = _pilotService.GetAllAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.Pilot> { _pilotDTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnPilotDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().GetAsync(_pilotId)).Returns(new List<Pilot> { _pilot });
            var result = _pilotService.GetDetailsAsync(_pilotId);
            Assert.AreEqual(_pilotDTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _pilotService.AddAsync(_pilotDTO);
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().CreateAsync(A<Pilot>.That.IsInstanceOf(typeof(Pilot)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _pilotService.UpdateAsync(_pilotDTO);
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().Update(A<Pilot>.That.IsInstanceOf(typeof(Pilot)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _pilotService.RemoveAsync(_pilotId);
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().Delete(_pilotId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _pilotService.RemoveAllAsync();
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().Delete(null)).MustHaveHappenedOnceExactly();
        }
    }*/
}
