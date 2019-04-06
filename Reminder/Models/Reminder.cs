namespace Reminder.Models
{
    using System;

    using Caliburn.Micro;

    public class Reminder : PropertyChangedBase
    {
        public Reminder(string task, DateTime start, TimeSpan duration)
        {
            Task = task;
            Start = start;
            Duration = duration;
            End = start + duration;
        }

        public string Task { get; }

        public DateTime Start { get; }

        public TimeSpan Duration { get; }

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