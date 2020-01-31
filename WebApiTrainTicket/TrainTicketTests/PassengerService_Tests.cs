using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using OnlineTrainTicketReservation.Repository;
using OnlineTrainTicketReservation.Services;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace TrainTicketTests
{
    [TestFixture]
    public class PassengerService_Tests
    {
        private PassengerService sut;
        private IDatabaseRepo repo;

        [SetUp]
        public void SetUp()
        {
            repo = A.Fake<IDatabaseRepo>();
            sut = new PassengerService(repo);
        }
        
        [Test]
        public void BookTicket_when_ticket_is_already_borrowed_throw_application_exception()
        {
            //Arrange
            A.CallTo(() => repo.HasPassengerReservedATicket(A<int>.Ignored)).Returns(true);

            //Assert
            Assert.Throws<ApplicationException>(() => sut.GetPassenger(1));
        }
    }
}
