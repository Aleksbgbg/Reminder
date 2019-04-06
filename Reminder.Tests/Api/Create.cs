namespace Reminder.Tests.Api
{
    using System;

    using Reminder.Models;

    internal static class Create
    {
        internal static Reminder Reminder(DateTime started, TimeSpan repeatPeriod)
        {
            return new Reminder(string.Empty, started, repeatPeriod);
        }
    }
}