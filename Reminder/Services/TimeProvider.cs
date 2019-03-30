namespace Reminder.Services
{
    using System;

    using Reminder.Services.Interfaces;

    public class TimeProvider : ITimeProvider
    {
        public DateTime CurrentTime => DateTime.Now;
    }
}