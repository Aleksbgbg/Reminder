namespace Reminder.Models
{
    using System;

    public class Reminder
    {
        public Reminder(string task, TimeSpan repeatPeriod)
        {
            Task = task;
            RepeatPeriod = repeatPeriod;
        }

        public string Task { get; }

        public TimeSpan RepeatPeriod { get; }
    }
}