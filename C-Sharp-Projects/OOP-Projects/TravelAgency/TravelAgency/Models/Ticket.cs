namespace TravelAgency.Models
{
    using System;

    public abstract class Ticket : IComparable<Ticket>
    {
        public abstract string TicketId { get; }

        public TicketType Type { get; protected set; }

        public string From { get; protected set; }

        public string To { get; protected set; }

        public DateTime DepartureDateTime { get; protected set; }

        public decimal Price { get; protected set; }

        public string FromToKey
        {
            get
            {
                return this.From + "; " + this.To;
            }
        }

        public override string ToString()
        {
            string result = "[" + this.DepartureDateTime.ToString("dd.MM.yyyy HH:mm") + "; " +
                this.Type.ToString().ToLowerInvariant() + "; " + string.Format("{0:f2}", this.Price) + "]";

            return result;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int result = this.DepartureDateTime.CompareTo(otherTicket.DepartureDateTime);
            if (result == 0)
            {
                result = string.Compare(this.Type.ToString(), otherTicket.Type.ToString(), StringComparison.InvariantCulture);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(otherTicket.Price);
            }

            return result;
        }
    }
}
