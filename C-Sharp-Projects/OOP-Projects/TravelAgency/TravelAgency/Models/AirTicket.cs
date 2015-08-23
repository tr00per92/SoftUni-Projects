namespace TravelAgency.Models
{
    using System;

    public class AirTicket : Ticket
    {
        public AirTicket(
            string flightNumber,
            string from, 
            string to, 
            string company, 
            DateTime departureDateTime, 
            decimal price)
            : this(flightNumber)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            this.DepartureDateTime = departureDateTime;
            this.Price = price;
        }

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
            this.Type = TicketType.Air;
        }

        public string Company { get; protected set; }

        public string FlightNumber { get; protected set; }
        
        public override string TicketId
        {
            get
            {
                return this.Type + ";" + this.FlightNumber;
            }
        }
    }
}
