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
    public class CrewServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<Crew> _fakeCrewRepository;
        private readonly IRepository<Pilot> _fakePilotRepository;
        private readonly IRepository<Stewardess> _fakeStewardessRepository;
        private readonly IMapper _fakeMapper;
        private CrewService _crewService;
        private int _crewId;
        private Crew _crew1;
        private DTO.Crew _crew1DTO;

        public CrewServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakeCrewRepository = A.Fake<IRepository<Crew>>();
            _fakePilotRepository = A.Fake<IRepository<Pilot>>();
            _fakeStewardessRepository = A.Fake<IRepository<Stewardess>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _crewId = 1;
            _crew1 = new Crew()
            {
                Id = 1, Pilot = new Pilot() { Id = _crewId, FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978, 03, 03), Experience = 9 },
                Stewardesses = new List<Stewardess> { new Stewardess() { Id = 1, CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993, 02, 03) } }
            };

            _crew1DTO = new DTO.Crew()
            {
                Id = 1, Pilot = new DTO.Pilot() { Id = _crewId, FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978, 03, 03), Experience = 9 },
                Stewardesses = new List<DTO.Stewardess> { new DTO.Stewardess() { Id = 1, CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993, 02, 03) } }
            };

            A.CallTo(() => _fakeMapper.Map<Crew, DTO.Crew>(_crew1)).Returns(_crew1DTO);
            A.CallTo(() => _fakeMapper.Map<DTO.Crew, Crew>(_crew1DTO)).Returns(_crew1);

            A.CallTo(() => _fakeUnitOfWork.CrewRepository).Returns(_fakeCrewRepository);
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>()).Returns(_fakePilotRepository);
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>()).Returns(_fakeStewardessRepository);
            _crewService = new CrewService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_PilotAndListStewardessesExist()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().GetAsync(null)).Returns(new List<Pilot> { _crew1.Pilot });
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().GetAsync(_crewId)).Returns(new List<Stewardess> { _crew1.Stewardesses.First() });
            var result = _crewService.ValidationForeignIdAsync(_crew1DTO);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_PilotDoesntExistListStewardessesExist()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().GetAsync(null)).Returns(new List<Pilot> {});
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().GetAsync(_crewId)).Returns(new List<Stewardess>{ _crew1.Stewardesses.First()});
            var result = _crewService.ValidationForeignIdAsync(_crew1DTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidationForeignId_Should_ReturnFalse_When_StewardessesDontExistPilotExists()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Pilot>().GetAsync(null)).Returns(new List<Pilot> { _crew1.Pilot });
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().GetAsync(_crewId)).Returns(new List<Stewardess> {});
            var result = _crewService.ValidationForeignIdAsync(_crew1DTO);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsExists_ShouldReturnCrewDto_WhenCrewExists()
        {
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(_crewId)).Returns(new List<Crew> { _crew1 });
            var result = _crewService.IsExistAsync(_crewId);
            Assert.AreEqual(_crew1DTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.Crew, Crew>(_crew1DTO)).Returns(_crew1);
            var result = _crewService.ConvertToModel(_crew1DTO);
            Assert.AreEqual(_crew1, result);
        }

        [Test]
        public void GetAll_Should_ReturnListCrewDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<Crew>, List<DTO.Crew>>(A<List<Crew>>.That.Contains(_crew1)))
                .Returns(new List<DTO.Crew> { _crew1DTO });
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(null)).Returns(new List<Crew> { _crew1 });
            List<DTO.Crew> result = _crewService.GetAllAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.Crew> { _crew1DTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnCrewDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.GetAsync(_crewId)).Returns(new List<Crew> { _crew1 });
            var result = _crewService.GetDetailsAsync(_crewId);
            Assert.AreEqual(_crew1DTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _crewService.AddAsync(_crew1DTO);
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.CreateAsync(_crew1, null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _crewService.UpdateAsync(_crew1DTO);
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.Update(_crew1, null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _crewService.RemoveAsync(_crewId);
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.Delete(_crewId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _crewService.RemoveAllAsync();
            A.CallTo(() => _fakeUnitOfWork.CrewRepository.Delete(null)).MustHaveHappenedOnceExactly();
        }
    }*/
}
