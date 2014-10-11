using System;
using System.Timers;

namespace _02_AsynchronousTimer
{
    public class AsyncTimer
    {
        public AsyncTimer(ElapsedEventHandler action, int ticks, int interval)
        {
            this.Timer = new Timer(interval);            
            this.Ticks = ticks;
            this.Timer.Elapsed += action;
            this.Timer.Elapsed += TickCounter;
            this.Timer.Enabled = true;
        }

        private Timer Timer { get; set; }
        private int Ticks { get; set; }

        private void TickCounter(Object sender, ElapsedEventArgs eventArgs)
        {
            this.Ticks--;
            if (this.Ticks <= 0)
            {
                this.Timer.Dispose();
            }
        }
    }
}
