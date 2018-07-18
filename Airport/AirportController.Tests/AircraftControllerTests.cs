using System;
using System.Net;
using BusinessLayer.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using PresentationLayer.Controllers;
using Shared.DTO;

namespace AirportController.Tests
{/*
    [TestFixture]
    public class AircraftControllerTests
    {
        private AircraftsController _aircraftsController;
        private readonly IService<Aircraft> _fakeAircraftService;
        private int _aircraftId;
        private Aircraft _plane;

        public AircraftControllerTests()
        {
            _fakeAircraftService = A.Fake<IService<Aircraft>>();
        }

        [SetUp]
        public void TestSetup()
        {
            _aircraftId = 1;
            _plane = new Aircraft()
            {
                AircraftName = "Strong",
                AircraftType = new AircraftType() { Id = 1, AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000 },
                AircraftReleaseDate = new DateTime(2011, 6, 10),
                ExploitationTimeSpan = new DateTime(2021, 6, 10) - new DateTime(2011, 6, 10)
            };

            _aircraftsController = new AircraftsController(_fakeAircraftService);
        }

        [TearDown]
        public void TestTearDown() { }

        [Test]
        public void GetAircraftDetails_Should_ReturnOk_When_Called()
        {
            A.CallTo(() => _fakeAircraftService.IsExistAsync(_aircraftId)).Returns(_plane);
            A.CallTo(() => _fakeAircraftService.GetDetailsAsync(_aircraftId)).Returns(_plane);
            var result = _aircraftsController.GetAircraftDetails(_aircraftId);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }

        [Test]
        public void GetAircraftDetails_Should_ReturnNotFound_When_Called()
        {
            A.CallTo(() => _fakeAircraftService.IsExistAsync(_aircraftId)).Returns(null);
            var result = _aircraftsController.GetAircraftDetails(_aircraftId);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Test]
        public void PostAircraft_Should_ReturnOk_When_Called()
        {
            A.CallTo(() => _fakeAircraftService.ValidationForeignIdAsync(_plane)).Returns(true);
            var result = _aircraftsController.PostAircraft(_plane);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            A.CallTo(() => _fakeAircraftService.AddAsync(_plane)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void PostAircraft_Should_ReturnBadRequest_When_AircraftIsNull()
        {
            var result = _aircraftsController.PostAircraft(null);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public void PostAircraft_Should_ReturnBadRequest_When_AircraftReleaseDateIsInFuture()
        {
            _plane.AircraftReleaseDate = DateTime.UtcNow.AddDays(1);
            var result = _aircraftsController.PostAircraft(_plane);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public void PostAircraft_Should_ReturnBadRequest_When_AircraftTypeDoesntExist()
        {
            A.CallTo(() => _fakeAircraftService.ValidationForeignIdAsync(_plane)).Returns(false);
            var result = _aircraftsController.PostAircraft(_plane);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public void PostAircraft_Should_ReturnBadRequest_When_AircraftHasId()
        {
            A.CallTo(() => _fakeAircraftService.ValidationForeignIdAsync(_plane)).Returns(true);
            _plane.Id = 1;
            var result = _aircraftsController.PostAircraft(_plane);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public void DeleteAircraft_Should_ReturnNoContent_When_Called()
        {
            A.CallTo(() => _fakeAircraftService.IsExistAsync(_aircraftId)).Returns(_plane);
            var result = _aircraftsController.DeleteAircraft(_aircraftId);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            A.CallTo(() => _fakeAircraftService.RemoveAsync(_aircraftId)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void DeleteAircraft_Should_ReturnNotFound_When_Called()
        {
            A.CallTo(() => _fakeAircraftService.IsExistAsync(_aircraftId)).Returns(null);
            var result = _aircraftsController.DeleteAircraft(_aircraftId);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            A.CallTo(() => _fakeAircraftService.RemoveAsync(_aircraftId)).MustNotHaveHappened();
        }

        [Test]
        public void DeleteAircrafts_Should_ReturnNoContent_When_Called()
        {
            var result = _aircraftsController.DeleteAircrafts();
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            A.CallTo(() => _fakeAircraftService.RemoveAllAsync()).MustHaveHappenedOnceExactly();
        }
    }*/
}
