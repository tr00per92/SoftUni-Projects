namespace Scoreboard
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var scoreboard = new Scoreboard();
            var input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split(' ');
                switch (tokens[0])
                {
                    case "RegisterUser":
                        Console.WriteLine(scoreboard.RegisterUser(tokens[1], tokens[2]));
                        break;
                    case "RegisterGame":
                        Console.WriteLine(scoreboard.RegisterGame(tokens[1], tokens[2]));
                        break;
                    case "AddScore":
                        Console.WriteLine(scoreboard.AddScore(tokens[1], tokens[2], tokens[3], tokens[4], int.Parse(tokens[5])));
                        break;
                    case "ShowScoreboard":
                        Console.WriteLine(scoreboard.ShowScoreboard(tokens[1]));
                        break;
                    case "ListGamesByPrefix":
                        Console.WriteLine(scoreboard.ListByPrefix(tokens[1]));
                        break;
                    case "DeleteGame":
                        Console.WriteLine(scoreboard.DeleteGame(tokens[1], tokens[2]));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
