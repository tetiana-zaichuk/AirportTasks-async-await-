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
    public class StewardessServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<Stewardess> _fakeStewardessRepository;
        private readonly IMapper _fakeMapper;
        private StewardessService _stewardessService;
        private int _stewardessId;
        private Stewardess _stewardess;
        private DTO.Stewardess _stewardessDTO;

        public StewardessServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakeStewardessRepository = A.Fake<IRepository<Stewardess>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _stewardessId = 1;
            _stewardess = new Stewardess() { Id=_stewardessId, CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993, 02, 03) };
            _stewardessDTO = new DTO.Stewardess() { Id = _stewardessId, CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993, 02, 03) };

            A.CallTo(() => _fakeMapper.Map<Stewardess, DTO.Stewardess>(_stewardess)).Returns(_stewardessDTO);
            A.CallTo(() => _fakeMapper.Map<DTO.Stewardess, Stewardess>(_stewardessDTO)).Returns(_stewardess);

            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>()).Returns(_fakeStewardessRepository);
            _stewardessService = new StewardessService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_Always()
        {
            Assert.IsTrue(_stewardessService.ValidationForeignIdAsync(_stewardessDTO));
        }

        [Test]
        public void IsExists_ShouldReturnStewardessDto_WhenStewardessExists()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().GetAsync(_stewardessId)).Returns(new List<Stewardess> { _stewardess });
            var result = _stewardessService.IsExistAsync(_stewardessId);
            Assert.AreEqual(_stewardessDTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.Stewardess, Stewardess>(_stewardessDTO)).Returns(_stewardess);
            var result = _stewardessService.ConvertToModel(_stewardessDTO);
            Assert.AreEqual(_stewardess, result);
        }

        [Test]
        public void GetAll_Should_ReturnListStewardessesDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<Stewardess>, List<DTO.Stewardess>>(A<List<Stewardess>>.That.Contains(_stewardess)))
                .Returns(new List<DTO.Stewardess> { _stewardessDTO });
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().GetAsync(null)).Returns(new List<Stewardess> { _stewardess });
            List<DTO.Stewardess> result = _stewardessService.GetAllAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.Stewardess> { _stewardessDTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnStewardessDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().GetAsync(_stewardessId)).Returns(new List<Stewardess> { _stewardess });
            var result = _stewardessService.GetDetailsAsync(_stewardessId);
            Assert.AreEqual(_stewardessDTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _stewardessService.AddAsync(_stewardessDTO);
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().CreateAsync(A<Stewardess>.That.IsInstanceOf(typeof(Stewardess)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _stewardessService.UpdateAsync(_stewardessDTO);
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().Update(A<Stewardess>.That.IsInstanceOf(typeof(Stewardess)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _stewardessService.RemoveAsync(_stewardessId);
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().Delete(_stewardessId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _stewardessService.RemoveAllAsync();
            A.CallTo(() => _fakeUnitOfWork.Set<Stewardess>().Delete(null)).MustHaveHappenedOnceExactly();
        }
    }*/
}
