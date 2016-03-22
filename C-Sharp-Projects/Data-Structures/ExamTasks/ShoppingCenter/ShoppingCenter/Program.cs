namespace ShoppingCenter
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var shoppingCenter = new ShoppingCenter();
            var commandsCount = int.Parse(Console.ReadLine() ?? "0");
            for (var i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine();
                if (!string.IsNullOrEmpty(command))
                {
                    var commandOutput = shoppingCenter.ProcessCommand(command);
                    Console.WriteLine(commandOutput);
                }
            }
        }
    }
}