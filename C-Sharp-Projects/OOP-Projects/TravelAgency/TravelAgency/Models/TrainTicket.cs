namespace TravelAgency.Models
{
    using System;

    public class TrainTicket : Ticket
    {
        public TrainTicket(
            string from,
            string to,
            DateTime departureDateTime,
            decimal price = 0,
            decimal studentPrice = 0)
        {
            this.From = from; 
            this.To = to;
            this.DepartureDateTime = departureDateTime;
            this.Price = price;
            this.StudentPrice = studentPrice;
            this.Type = TicketType.Train;
        }

        public decimal StudentPrice { get; protected set; }

        public override string TicketId
        {
            get
            {
                return this.Type + ";" + this.From + ";" + this.To + ";" + this.DepartureDateTime + ";";
            }
        }
    }
}
