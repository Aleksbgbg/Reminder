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

        public bool IsExpired(Reminder reminder)
        {
            return reminder.End < _timeProvider.CurrentTime;
        }

        public TimeSpan TimeLeftToFulfillReminder(Reminder reminder)
        {
            return reminder.End - _timeProvider.CurrentTime;
        }
    }
}