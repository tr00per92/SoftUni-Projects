namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Models;

    [TestClass]
    public class TicketCatalogTests
    {
        private ITicketCatalog ticketCatalog;

        [TestInitialize]
        public void TestInitialize()
        {
            this.ticketCatalog = new TicketCatalog();
        }

        [TestMethod]
        public void TestTicketCount()
        {
            this.ticketCatalog.AddAirTicket("113213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);
            this.ticketCatalog.AddAirTicket("1123213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);
            this.ticketCatalog.AddAirTicket("11233", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);
            
            this.ticketCatalog.AddBusTicket("Tokyo", "Pas", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            this.ticketCatalog.AddBusTicket("Tokyo", "Par", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            this.ticketCatalog.AddBusTicket("Tokyo", "Moskow", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            
            this.ticketCatalog.AddTrainTicket("Tok", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            
            Assert.AreEqual(2, this.ticketCatalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(4, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(3, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicket()
        {
            var result = this.ticketCatalog.AddAirTicket("1123213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddExistingAirTicket()
        {
            this.ticketCatalog.AddAirTicket("1123213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);
            var result = this.ticketCatalog.AddAirTicket("1123213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);

            Assert.AreEqual("Duplicate ticket", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicket()
        {
            this.ticketCatalog.AddAirTicket("1123213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);
            var result = this.ticketCatalog.DeleteAirTicket("1123213");

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteUnexistingAirTicket()
        {
            this.ticketCatalog.AddAirTicket("1123213", "Tokyo", "Paris", "BulgariaAir", new DateTime(2014, 5, 8), 1500);
            var result = this.ticketCatalog.DeleteAirTicket("3124215");

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddBusTicket()
        {
            var result = this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1500);

            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void TestAddExistingBusTicket()
        {
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            var result = this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1500);

            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void TestDeleteBusTicket()
        {
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            var result = this.ticketCatalog.DeleteBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8));

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteUnexistingBusTicket()
        {
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1500);
            var result = this.ticketCatalog.DeleteBusTicket("Tokyo", "Paris", "company", new DateTime(2014, 5, 8));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddTrainTicket()
        {
            var result = this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);

            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void TestAddExistingTrainTicket()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            var result = this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);

            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void TestDeleteTrainTicket()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            var result = this.ticketCatalog.DeleteTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8));

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteUnexistingTrainTicket()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            var result = this.ticketCatalog.DeleteTrainTicket("Tokyo", "Paris", new DateTime(2015, 5, 8));

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestFindTickets()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1400);
            var result = this.ticketCatalog.FindTickets("Tokyo", "Paris");

            Assert.AreEqual("[08.05.2014 00:00; bus; 1400.00] [08.05.2014 00:00; train; 1500.00]", result);
        }

        [TestMethod]
        public void TestFindUnexistingTickets()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 8), 1500, 1000);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1400);
            var result = this.ticketCatalog.FindTickets("Moskow", "Paris");

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void TestFindTicketsInInterval()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 16), 1500, 1000);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1200);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 4, 8), 1400);
            var result = this.ticketCatalog.FindTicketsInInterval(new DateTime(2014, 5, 1), new DateTime(2014, 5, 31));

            Assert.AreEqual("[08.05.2014 00:00; bus; 1200.00] [16.05.2014 00:00; train; 1500.00]", result);
        }

        [TestMethod]
        public void TestFindUnexistingTicketsInInterval()
        {
            this.ticketCatalog.AddTrainTicket("Tokyo", "Paris", new DateTime(2014, 5, 16), 1500, 1000);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 5, 8), 1200);
            this.ticketCatalog.AddBusTicket("Tokyo", "Paris", "Bus Ltd", new DateTime(2014, 4, 8), 1400);
            var result = this.ticketCatalog.FindTicketsInInterval(new DateTime(2015, 5, 1), new DateTime(2015, 5, 31));

            Assert.AreEqual("Not found", result);
        }
    }
}
