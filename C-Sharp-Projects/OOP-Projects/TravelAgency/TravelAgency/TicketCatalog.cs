namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using TravelAgency.Models;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private const string TicketAddedString = "Ticket added";
        private const string TicketDeletedString = "Ticket deleted";
        private const string DuplicateTicketString = "Duplicate ticket";
        private const string TicketNotFoundString = "Not found";
        private const string UnexistingTicketString = "Ticket does not exist";

        private const string AddAirTicketCommand = "AddAir";
        private const string DeleteAirTicketCommand = "DeleteAir";
        private const string AddTrainTicketCommand = "AddTrain";
        private const string DeleteTrainTicketCommand = "DeleteTrain";
        private const string AddBusTicketCommand = "AddBus";
        private const string DeleteBusTicketCommand = "DeleteBus";
        private const string FindTicketsCommand = "FindTickets";
        private const string FindTicketsInIntervalCommand = "FindTicketsInInterval";

        private readonly Dictionary<string, Ticket> ticketsById = new Dictionary<string, Ticket>();
        private readonly MultiDictionary<string, Ticket> ticketsByFromToKey = new MultiDictionary<string, Ticket>(true);
        private readonly OrderedMultiDictionary<DateTime, Ticket> ticketsByDepartureDateTime = new OrderedMultiDictionary<DateTime, Ticket>(true);

        private int airTicketsCount;
        private int busTicketsCount;
        private int trainTicketsCount;

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Air)
            {
                return this.airTicketsCount;
            }
            
            if (type == TicketType.Bus)
            {
                return this.busTicketsCount;
            }
            
            if (type == TicketType.Train)
            {
                return this.trainTicketsCount;
            }

            throw new ArgumentException("Unsupported ticket type");
        }

        public string ProcessCommand(string inputLine)
        {
            if (string.IsNullOrWhiteSpace(inputLine))
            {
                throw new ArgumentNullException("inputLine", "The input line cannot be null or empty.");
            }

            int firstSpaceIndex = inputLine.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                throw new ArgumentException("Invalid command format.");
            }

            string commandType = inputLine.Substring(0, firstSpaceIndex);
            string commandParametersString = inputLine.Substring(firstSpaceIndex + 1);
            string[] commandParameters = commandParametersString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < commandParameters.Length; i++)
            {
                commandParameters[i] = commandParameters[i].Trim();
            }

            switch (commandType)
            {
                case TicketCatalog.AddAirTicketCommand:
                    return this.ProcessAddAirTicketCommand(commandParameters);

                case TicketCatalog.DeleteAirTicketCommand:
                    return this.ProcessDeleteAirTicketCommand(commandParameters);

                case TicketCatalog.AddTrainTicketCommand:
                    return this.ProcessAddTrainTicketCommand(commandParameters);

                case TicketCatalog.DeleteTrainTicketCommand:
                    return this.ProcessDeleteTrainTicketCommand(commandParameters);

                case TicketCatalog.AddBusTicketCommand:
                    return this.ProcessAddBusTicketCommand(commandParameters);

                case TicketCatalog.DeleteBusTicketCommand:
                    return this.ProcessDeleteBusTicketCommand(commandParameters);
                    
                case TicketCatalog.FindTicketsCommand:
                    return this.ProcessFindTicketsCommand(commandParameters);

                case TicketCatalog.FindTicketsInIntervalCommand:
                    return this.ProcessFindTicketsInIntervalCommand(commandParameters);

                default:
                    throw new ArgumentException("Unsupported command.");
            }
        }

        public string AddAirTicket(
            string flightNumber, 
            string from,
            string to,
            string airlineCompany, 
            DateTime departureDateTime,
            decimal price)
        {
            var ticket = new AirTicket(flightNumber, from, to, airlineCompany, departureDateTime, price);

            string result = this.AddTicket(ticket);
            if (result == TicketCatalog.TicketAddedString)
            {
                this.airTicketsCount++;
            }

            return result;
        }
        
        public string DeleteAirTicket(string flightNumber)
        {
            var ticket = new AirTicket(flightNumber);

            string result = this.DeleteTicket(ticket);
            if (result == TicketCatalog.TicketDeletedString)
            {
                this.airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(
            string from, 
            string to, 
            DateTime departureDateTime, 
            decimal price,
            decimal studentPrice)
        {
            var ticket = new TrainTicket(from, to, departureDateTime, price, studentPrice);

            string result = this.AddTicket(ticket);
            if (result == TicketCatalog.TicketAddedString)
            {
                this.trainTicketsCount++;
            }

            return result;
        }

        public string DeleteTrainTicket(
            string from, 
            string to,
            DateTime departureDateTime)
        {
            var ticket = new TrainTicket(from, to, departureDateTime);
            string result = this.DeleteTicket(ticket);

            if (result == TicketCatalog.TicketDeletedString)
            {
                this.trainTicketsCount--;
            }

            return result;
        }

        public string AddBusTicket(
            string from,
            string to,
            string company, 
            DateTime departureDateTime, 
            decimal price)
        {
            var ticket = new BusTicket(from, to, company, departureDateTime, price);
            string key = ticket.TicketId;
            string result;

            if (this.ticketsById.ContainsKey(key))
            {
                result = TicketCatalog.DuplicateTicketString;
            }
            else
            {
                this.ticketsById.Add(key, ticket);
                string fromToKey = ticket.FromToKey;
                this.ticketsByFromToKey.Add(fromToKey, ticket);
                this.ticketsByDepartureDateTime.Add(ticket.DepartureDateTime, ticket);
                result = TicketCatalog.TicketAddedString;
            }

            if (result == TicketCatalog.TicketAddedString)
            {
                this.busTicketsCount++;
            }

            return result;
        }
       
        public string DeleteBusTicket(
            string from,
            string to, 
            string company, 
            DateTime departureDateTime)
        {
            var ticket = new BusTicket(from, to, company, departureDateTime);
            string result = this.DeleteTicket(ticket);

            if (result == TicketCatalog.TicketDeletedString)
            {
                this.busTicketsCount--;
            }

            return result;
        }
        
        public string FindTickets(string from, string to)
        {
            string fromToKey = from + "; " + to;

            if (this.ticketsByFromToKey.ContainsKey(fromToKey))
            {
                // bottleneck - ticket searching was inefficient
                ICollection<Ticket> ticketsFound = this.ticketsByFromToKey[fromToKey];
                string ticketsAsString = TicketCatalog.TicketsToString(ticketsFound);
                return ticketsAsString;
            }
            
            return TicketCatalog.TicketNotFoundString;
        }
        
        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            // bottleneck - this method is more efficient than the other
            var ticketsFound = this.ticketsByDepartureDateTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = TicketCatalog.TicketsToString(ticketsFound); 
                return ticketsAsString;
            }

            return TicketCatalog.TicketNotFoundString;
        }

        private static string TicketsToString(IEnumerable<Ticket> tickets)
        {
            List<Ticket> sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();

            // bottleneck - the previous string concatenation was inefficient
            string result = string.Join(" ", sortedTickets);

            return result;
        }

        private string ProcessFindTicketsInIntervalCommand(string[] commandParameters)
        {
            var startDateTime = DateTime.ParseExact(commandParameters[0], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var endDateTime = DateTime.ParseExact(commandParameters[1], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var commandResult = this.FindTicketsInInterval(startDateTime, endDateTime);
            return commandResult;
        }

        private string ProcessFindTicketsCommand(string[] commandParameters)
        {
            var from = commandParameters[0];
            var to = commandParameters[1];

            var commandResult = this.FindTickets(from, to);
            return commandResult;
        }

        private string ProcessDeleteBusTicketCommand(string[] commandParameters)
        {
            var from = commandParameters[0];
            var to = commandParameters[1];
            var company = commandParameters[2];
            var departureDateTime = DateTime.ParseExact(commandParameters[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var commandResult = this.DeleteBusTicket(from, to, company, departureDateTime);
            return commandResult;
        }

        private string ProcessAddBusTicketCommand(string[] commandParameters)
        {
            var from = commandParameters[0];
            var to = commandParameters[1];
            var company = commandParameters[2];
            var departureDateTime = DateTime.ParseExact(commandParameters[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var price = decimal.Parse(commandParameters[4]);

            var commandResult = this.AddBusTicket(from, to, company, departureDateTime, price);
            return commandResult;
        }

        private string ProcessDeleteTrainTicketCommand(string[] commandParameters)
        {
            var from = commandParameters[0];
            var to = commandParameters[1];
            var departureDateTime = DateTime.ParseExact(commandParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var commandResult = this.DeleteTrainTicket(from, to, departureDateTime);
            return commandResult;
        }

        private string ProcessAddTrainTicketCommand(string[] commandParameters)
        {
            var from = commandParameters[0];
            var to = commandParameters[1];
            var departureDateTime = DateTime.ParseExact(commandParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var price = decimal.Parse(commandParameters[3]);
            var studentPrice = decimal.Parse(commandParameters[3]);

            var commandResult = this.AddTrainTicket(@from, to, departureDateTime, price, studentPrice);
            return commandResult;
        }

        private string ProcessDeleteAirTicketCommand(string[] commandParameters)
        {
            var flightNumber = commandParameters[0];

            var commandResult = this.DeleteAirTicket(flightNumber);
            return commandResult;
        }

        private string ProcessAddAirTicketCommand(string[] commandParameters)
        {
            var flightNumber = commandParameters[0];
            var from = commandParameters[1];
            var to = commandParameters[2];
            var company = commandParameters[3];
            var departureDateTime = DateTime.ParseExact(commandParameters[4], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var price = decimal.Parse(commandParameters[5]);

            var commandResult = this.AddAirTicket(flightNumber, from, to, company, departureDateTime, price);
            return commandResult;
        }

        private string AddTicket(Ticket ticket)
        {
            string ticketId = ticket.TicketId;
            if (this.ticketsById.ContainsKey(ticketId))
            {
                return TicketCatalog.DuplicateTicketString;
            }

            this.ticketsById.Add(ticketId, ticket);
            this.ticketsByFromToKey.Add(ticket.FromToKey, ticket);
            this.ticketsByDepartureDateTime.Add(ticket.DepartureDateTime, ticket);

            return TicketCatalog.TicketAddedString;
        }

        private string DeleteTicket(Ticket ticket)
        {
            string ticketId = ticket.TicketId;
            if (this.ticketsById.ContainsKey(ticketId))
            {
                this.ticketsById.Remove(ticketId);
                this.ticketsByFromToKey.Remove(ticket.FromToKey, ticket);
                this.ticketsByDepartureDateTime.Remove(ticket.DepartureDateTime, ticket);

                return TicketCatalog.TicketDeletedString;
            }

            return TicketCatalog.UnexistingTicketString;
        }
    }
}
