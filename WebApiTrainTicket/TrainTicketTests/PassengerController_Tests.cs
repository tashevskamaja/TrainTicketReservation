using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using WebApiTrainTicket.Controllers;
using OnlineTrainTicketReservation.Services;
using OnlineTrainTicketReservation.Models;
using NUnit.Framework;
using System.Net;
using Assert = NUnit.Framework.Assert;

namespace TrainTicketTests
{
    [TestFixture]
    public class PassengerController_Tests
    {
        private PassengerController sut;
        private IPassengerService service;

        [SetUp]
        public void SetUp()
        {
            service = A.Fake<IPassengerService>();
            sut = new PassengerController(service);
            sut.Request = new System.Net.Http.HttpRequestMessage();
        }

        [Test]
        public void BookTicket_when_ticket_successfully_is_booked_return_ok()
        {
            //Arrange
            int ticket_id = 1;
            A.CallTo(() => service.BookTicket(A<int>.Ignored, A<int>.Ignored, A<Reservation>.Ignored)).Returns(true);

            //Act
            var result = sut.BookTicket(1, ticket_id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result);
        }
    }
}
