namespace TravelAgency
{
    using System;

    public class ProgramEntryPoint
    {
        public static void Main()
        {
            var ticketCatalog = new TicketCatalog();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == null)
                {
                    break;
                }

                try
                {
                    string commandResult = ticketCatalog.ProcessCommand(inputLine.Trim());
                    Console.WriteLine(commandResult);
                }
                catch (ArgumentException)
                {
                    // the input will always be valid
                }
            }
        }
    }
}
