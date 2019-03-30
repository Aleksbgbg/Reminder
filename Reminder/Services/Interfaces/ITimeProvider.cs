namespace Reminder.Services.Interfaces
{
    using System;

    public interface ITimeProvider
    {
        DateTime CurrentTime { get; }
    }
}