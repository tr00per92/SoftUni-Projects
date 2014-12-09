using System;
using System.Timers;

namespace _02_AsynchronousTimer
{
    public class AsynchronousTimer
    {
        public static void Main()
        {
            AsyncTimer timer = new AsyncTimer(Action, 8, 500);
            Console.ReadLine();
        }

        public static void Action(Object sender, ElapsedEventArgs eventArgs)
        {
            Console.WriteLine("I am doing something.");
        }
    }
}
