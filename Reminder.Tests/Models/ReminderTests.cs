namespace Reminder.Tests.Models
{
    using System;

    using Reminder.Models;
    using Reminder.Tests.Api;

    using Xunit;

    public class ReminderTests
    {
        [Fact]
        public void TestEndsAtCorrectTime()
        {
            // Arrange
            DateTime start = Constants.DefaultStartDate;
            TimeSpan duration = Constants.DefaultDuration;

            // Act
            Reminder reminder = Create.Reminder(start, duration);

            // Assert
            Assert.Equal(start + duration, reminder.End);
        }
    }
}