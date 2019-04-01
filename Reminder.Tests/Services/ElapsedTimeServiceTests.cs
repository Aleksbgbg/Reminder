namespace Reminder.Tests.Services
{
    using System;

    using Moq;

    using Reminder.Models;
    using Reminder.Services;
    using Reminder.Services.Interfaces;

    using Xunit;

    public class ElapsedTimeServiceTests
    {
        [Fact]
        public void TestComputesReminderFulfillTimeCorrectly()
        {
            // Arrange
            DateTime timeNow = new DateTime(2020, 6, 15, 12, 37, 48);

            Mock<ITimeProvider> timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.SetupGet(timeProvider => timeProvider.CurrentTime)
                            .Returns(timeNow);

            DateTime startDate = timeNow - TimeSpan.FromDays(3);
            TimeSpan repeatPeriod = TimeSpan.FromDays(5);
            TimeSpan expectedRemainingTime = (startDate + repeatPeriod) - timeNow;

            Reminder reminder = new Reminder(string.Empty, startDate, repeatPeriod);

            ElapsedTimeService elapsedTimeService = new ElapsedTimeService(timeProviderMock.Object);

            // Act
            TimeSpan actualRemainingTime = elapsedTimeService.TimeLeftToFulfillReminder(reminder);

            // Assert
            Assert.Equal(expectedRemainingTime, actualRemainingTime);
        }
    }
}