namespace Reminder.Services.Interfaces
{
    using System;

    using Reminder.Models;

    public interface IElapsedTimeService
    {
        bool IsExpired(Reminder reminder);

        TimeSpan TimeLeftToFulfillReminder(Reminder reminder);
    }
}