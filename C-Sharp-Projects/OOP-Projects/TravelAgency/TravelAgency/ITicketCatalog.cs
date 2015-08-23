namespace TravelAgency
{
    using System;
    using TravelAgency.Models;

    /// <summary>
    /// Contains methods for adding, removing and searching tickets in a ticket catalog
    /// </summary>
    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds a new air ticket to the catalog
        /// </summary>
        /// <param name="flightNumber">The flight number</param>
        /// <param name="from">The departure airport</param>
        /// <param name="to">The arrival airport</param>
        /// <param name="airline">The airline company</param>
        /// <param name="dateTime">The departure date and time</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Success or error message</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        string AddBusTicket(string from, string to, string company, DateTime dateTime, decimal price);

        /// <summary>
        /// Removes a bus ticket form the catalog
        /// </summary>
        /// <param name="from">The departure town</param>
        /// <param name="to">The arrival town</param>
        /// <param name="company">The travel company</param>
        /// <param name="dateTime">The departure date and time</param>
        /// <returns>Success or error message</returns>
        string DeleteBusTicket(string from, string to, string company, DateTime dateTime);

        /// <summary>
        /// Finds all tickets for travels between the specified destinations
        /// </summary>
        /// <param name="from">The departure destination</param>
        /// <param name="to">The arrival destination</param>
        /// <returns>The tickets found as string or error message</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Finds all tickets for travels in the specifield time interval
        /// </summary>
        /// <param name="startDateTime">The start departure date and time for the search</param>
        /// <param name="endDateTime">The ned departure date and time for the search</param>
        /// <returns>The tickets found as string or error message</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}
