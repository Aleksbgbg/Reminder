namespace Reminder.Services
{
    using System;
    using System.Timers;

    using Reminder.Services.Interfaces;

    public class TimerService : ITimerService
    {
        public TimerService()
        {
            Timer timer = new Timer(1000.0);
            timer.Elapsed += InvokeSecondElapsed;
            timer.Start();
        }

        public event EventHandler SecondElapsed;

        private void InvokeSecondElapsed(object sender, ElapsedEventArgs e)
        {
            SecondElapsed?.Invoke(this, EventArgs.Empty);
        }
    }
}