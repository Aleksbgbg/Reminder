namespace Reminder.Tests.Api
{
    using System;

    using Reminder.Models;

    internal static class Create
    {
        internal static Reminder Reminder()
        {
            return Reminder(TimeSpan.Zero);
        }

        internal static Reminder Reminder(TimeSpan repeatPeriod)
        {
            return Reminder(Constants.DefaultStartDate, repeatPeriod);
        }

        internal static Reminder Reminder(DateTime started, TimeSpan repeatPeriod)
        {
            return new Reminder(string.Empty, started, repeatPeriod);
        }
    }
}