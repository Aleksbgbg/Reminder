namespace Reminder.Tests.Services
{
    using System;

    using Moq;

    using Reminder.Models;
    using Reminder.Services;
    using Reminder.Services.Interfaces;
    using Reminder.Tests.Api;

    using Xunit;

    public class ElapsedTimeServiceTests
    {
        [Fact]
        public void TestComputesReminderFulfillTimeCorrectly()
        {
            // Arrange
            DateTime timeNow = Constants.DefaultStartDate;

            Mock<ITimeProvider> timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.SetupGet(timeProvider => timeProvider.CurrentTime)
                            .Returns(timeNow);

            DateTime startDate = timeNow - TimeSpan.FromDays(3);
            TimeSpan repeatPeriod = TimeSpan.FromDays(5);
            TimeSpan expectedRemainingTime = (startDate + repeatPeriod) - timeNow;

            Reminder reminder = Create.Reminder(startDate, repeatPeriod);

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
            DateTime timeNow = Constants.DefaultStartDate;

            Reminder reminder = Create.Reminder(timeNow, TimeSpan.Zero);

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