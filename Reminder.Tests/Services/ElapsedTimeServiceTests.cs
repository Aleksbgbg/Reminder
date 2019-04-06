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

        [Fact]
        public void TestDeterminesReminderExpiryCorrectly()
        {
            // Arrange
            DateTime timeNow = new DateTime(2020, 6, 15, 12, 37, 48);

            Reminder reminder = new Reminder(string.Empty, timeNow, TimeSpan.Zero);

            Mock<ITimeProvider> timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.SetupGet(timeProvider => timeProvider.CurrentTime)
                            .Returns(timeNow + TimeSpan.FromMilliseconds(1.0));

            ElapsedTimeService elapsedTimeService = new ElapsedTimeService(timeProviderMock.Object);

            // Act
            bool isReminderExpired = elapsedTimeService.IsExpired(reminder);

            // Assert
            Assert.True(isReminderExpired);
        }
    }
}