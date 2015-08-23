namespace TravelAgency.Models
{
    using System;

    public class BusTicket : Ticket
    {
        public BusTicket(
            string from,
            string to, 
            string company,
            DateTime departureDateTime, 
            decimal price = 0)
        {
            this.From = from;
            this.To = to;
            this.Company = company;
            this.DepartureDateTime = departureDateTime;
            this.Price = price;
            this.Type = TicketType.Bus;
        }

        public string Company { get; protected set; }

        public override string TicketId
        {
            get
            {
                return this.Type + ";" + this.From + ";" + this.To + ";" + this.Company + this.DepartureDateTime + ";";
            }
        }
    }
}
