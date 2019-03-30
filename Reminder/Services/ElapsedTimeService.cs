namespace Reminder.Services
{
    using System;

    using Reminder.Models;
    using Reminder.Services.Interfaces;

    public class ElapsedTimeService : IElapsedTimeService
    {
        private readonly ITimeProvider _timeProvider;

        public ElapsedTimeService(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public TimeSpan TimeLeftToFulfillReminder(Reminder reminder)
        {
            return (reminder.Started + reminder.RepeatPeriod) - _timeProvider.CurrentTime;
        }
    }
}