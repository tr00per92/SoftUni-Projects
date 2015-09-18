namespace MongoDbChat.ConsoleClient
{
    using System;
    using System.Timers;
    using MongoDbChat.Data;

    public class ConsoleClient
    {
        private static readonly MongoDbContext mongoDbContext = new MongoDbContext();
        private static string username;

        public static void Main()
        {
            Console.Write("Please enter your username: ");
            username = Console.ReadLine();
            PrintMessages();
            StartTimer();
            MainLoop();
        }

        private static void MainLoop()
        {
            while (true)
            {
                mongoDbContext.AddMessage(new Message
                {
                    Text = Console.ReadLine(),
                    Username = username,
                    Date = DateTime.Now
                });
            }
        }

        private async static void PrintMessages()
        {
            var messages = await mongoDbContext.GetMessagesAsync();
            Console.Clear();
            Console.WriteLine(string.Join(Environment.NewLine, messages));
            Console.Write("Enter message: ");
        }

        private static void StartTimer()
        {
            var timer = new Timer { Interval = 1000 };
            timer.Elapsed += UpdateMessages;
            timer.Start();
        }

        private static async void UpdateMessages(object sender, EventArgs eventArgs)
        {
            if (await mongoDbContext.HasNewMessagesAsync())
            {
                PrintMessages();
            }
        }
    }
}
