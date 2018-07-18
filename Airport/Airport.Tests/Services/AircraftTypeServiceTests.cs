using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using FakeItEasy;
using NUnit.Framework;
using DTO = Shared.DTO;

namespace Airport.Tests.Services
{
    [TestFixture]
    public class AircraftTypeServiceTests
    {
        private readonly IUnitOfWork _fakeUnitOfWork;
        private readonly IRepository<AircraftType> _fakeAircraftTypeRepository;
        private readonly IMapper _fakeMapper;
        private AircraftTypeService _aircraftTypeService;
        private int _aircraftTypeId;
        private AircraftType _type1;
        private DTO.AircraftType _type1DTO;

        public AircraftTypeServiceTests()
        {
            _fakeUnitOfWork = A.Fake<IUnitOfWork>();
            _fakeAircraftTypeRepository = A.Fake<IRepository<AircraftType>>();
            _fakeMapper = A.Fake<IMapper>();
        }

        // This method runs before each test.
        [SetUp]
        public void TestSetup()
        {
            _aircraftTypeId = 1;
            _type1 = new AircraftType() { Id = _aircraftTypeId, AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 };
            _type1DTO = new DTO.AircraftType() { Id = _aircraftTypeId, AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 };

            A.CallTo(() => _fakeMapper.Map<AircraftType, DTO.AircraftType>(_type1)).Returns(_type1DTO);
            A.CallTo(() => _fakeMapper.Map<DTO.AircraftType, AircraftType>(_type1DTO)).Returns(_type1);

            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>()).Returns(_fakeAircraftTypeRepository);
            _aircraftTypeService = new AircraftTypeService(_fakeUnitOfWork, _fakeMapper);
        }

        // This method runs after each test.
        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void ValidationForeignId_Should_ReturnTrue_When_Always()
        {
            Assert.IsTrue(_aircraftTypeService.ValidationForeignId(_type1DTO));
        }

        [Test]
        public void IsExists_ShouldReturnAircraftTypeDto_WhenAircraftTypeExists()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Get(_aircraftTypeId)).Returns(new List<AircraftType> { _type1 });
            var result = _aircraftTypeService.IsExist(_aircraftTypeId);
            Assert.AreEqual(_type1DTO, result);
        }

        [Test]
        public void ConvertToModel_Should_ReturnModel_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<DTO.AircraftType, AircraftType>(_type1DTO)).Returns(_type1);
            var result = _aircraftTypeService.ConvertToModel(_type1DTO);
            Assert.AreEqual(_type1, result);
        }

        [Test]
        public void GetAll_Should_ReturnListAircraftTypeDTO_When_Called()
        {
            A.CallTo(() => _fakeMapper.Map<List<AircraftType>, List<DTO.AircraftType>>(A<List<AircraftType>>.That.Contains(_type1)))
                .Returns(new List<DTO.AircraftType> { _type1DTO });
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Get(null)).Returns(new List<AircraftType> { _type1 });
            List<DTO.AircraftType> result = _aircraftTypeService.GetAll();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new List<DTO.AircraftType> { _type1DTO }, result);
        }

        [Test]
        public void GetDetails_Should_ReturnAircraftTypeDTO_When_Called()
        {
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Get(_aircraftTypeId)).Returns(new List<AircraftType> { _type1 });
            var result = _aircraftTypeService.GetDetails(_aircraftTypeId);
            Assert.AreEqual(_type1DTO, result);
        }

        [Test]
        public void Add_Should_CallRepositoryCreate_When_Called()
        {
            _aircraftTypeService.Add(_type1DTO);
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Create(A<AircraftType>.That.IsInstanceOf(typeof(AircraftType)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Update_Should_CallRepositoryUpdate_When_Called()
        {
            _aircraftTypeService.Update(_type1DTO);
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Update(A<AircraftType>.That.IsInstanceOf(typeof(AircraftType)), null)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Remove_Should_CallRepositoryRemove_When_Called()
        {
            _aircraftTypeService.Remove(_aircraftTypeId);
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Delete(_aircraftTypeId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void RemoveAll_Should_CallRepositoryRemoveAll_When_Called()
        {
            _aircraftTypeService.RemoveAll();
            A.CallTo(() => _fakeUnitOfWork.Set<AircraftType>().Delete(null)).MustHaveHappenedOnceExactly();
        }
    }
}
