namespace Reminder.Services.Interfaces
{
    using System;

    using Reminder.Models;

    public interface IElapsedTimeService
    {
        TimeSpan TimeLeftToFulfillReminder(Reminder reminder);
    }
}