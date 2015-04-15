namespace Battleships.ConsoleClient
{
    using System;

    public class BattleshipsClient
    {
        public static void Main()
        {
            var api = new BattleshipsConsoleApi();
            while (true)
            {
                Console.WriteLine("Enter command: ");
                try
                {
                    var command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    switch (command[0])
                    {
                        // register {email} {password} {confirmpassword}
                        case "register":
                            Console.WriteLine(api.Register(command[1], command[2], command[3]));
                            break;
                        // login {email} {password}
                        case "login":
                            Console.WriteLine(api.Login(command[1], command[2]));
                            break;
                        // creates a new game
                        case "create":
                            Console.WriteLine(api.CreateGame());
                            break;
                        // join {gameID} -> joins and starts playing in the selected game
                        case "join":
                            Console.WriteLine(api.JoinGame(command[1]));
                            Console.WriteLine(api.GetField());
                            break;
                        // setgame {gameID} -> manually sets the game id, if continuing a game for example
                        case "setgame":
                            Console.WriteLine(api.SetGame(command[1]));
                            Console.WriteLine(api.GetField());
                            break;
                        // setgame {X} {Y} -> hits the field with the selected coordinates
                        case "play":
                            Console.WriteLine(api.Play(int.Parse(command[1]), int.Parse(command[2])));
                            Console.WriteLine(api.GetField());
                            break;
                        // gets the available games
                        case "getgames":
                            Console.WriteLine(api.GetAvailableGames());
                            break;
                        // gets the unfinished games of the current user
                        case "mygames":
                            Console.WriteLine(api.GetMyGames());
                            break;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Please try again");
                }
            }
        }
    }
}
