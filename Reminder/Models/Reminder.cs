namespace Reminder.Models
{
    using System;

    public class Reminder
    {
        public Reminder(string task, DateTime started, TimeSpan repeatPeriod)
        {
            Task = task;
            Started = started;
            RepeatPeriod = repeatPeriod;
            End = started + repeatPeriod;
        }

        public string Task { get; }

        public DateTime Started { get; }

        public TimeSpan RepeatPeriod { get; }

        public DateTime End { get; }
    }
}