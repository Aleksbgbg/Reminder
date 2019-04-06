namespace Reminder.Models
{
    using System;

    using Caliburn.Micro;

    public class Reminder : PropertyChangedBase
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

        private bool _expired;
        public bool Expired
        {
            get => _expired;

            set
            {
                if (_expired == value) return;

                _expired = value;
                NotifyOfPropertyChange(nameof(Expired));
            }
        }
    }
}