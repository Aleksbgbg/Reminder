﻿namespace Reminder.Tests.Models
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
            DateTime start = new DateTime(2020, 6, 15);
            TimeSpan duration = TimeSpan.FromDays(3);

            // Act
            Reminder reminder = Create.Reminder(start, duration);

            // Assert
            Assert.Equal(start + duration, reminder.End);
        }
    }
}