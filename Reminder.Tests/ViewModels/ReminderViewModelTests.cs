namespace Reminder.Tests.ViewModels
{
    using System;

    using Moq;

    using Reminder.Models;
    using Reminder.Services.Interfaces;
    using Reminder.ViewModels;

    using Xunit;

    public class ReminderViewModelTests
    {
        [Fact]
        public void TestUpdatesRemainingReminderDuration()
        {
            // Arrange
            TimeSpan reminderDuration = TimeSpan.FromMilliseconds(5000);
            TimeSpan elapsedTime = TimeSpan.FromMilliseconds(1500);
            TimeSpan newReminderDuration = reminderDuration - elapsedTime;

            Reminder reminder = new Reminder(string.Empty, DateTime.Today, reminderDuration);

            Mock<ITimerService> timerMock = new Mock<ITimerService>();

            Mock<IElapsedTimeService> elapsedTimeServiceMock = new Mock<IElapsedTimeService>();
            elapsedTimeServiceMock.Setup(elapsedTimeService => elapsedTimeService.TimeLeftToFulfillReminder(reminder))
                                  .Returns(newReminderDuration);

            ReminderViewModel reminderViewModel = new ReminderViewModel(timerMock.Object, elapsedTimeServiceMock.Object, reminder);

            // Act
            timerMock.Raise(timerService => timerService.SecondElapsed += null, EventArgs.Empty);

            // Assert
            Assert.Equal(newReminderDuration, reminderViewModel.RemainingTime);
        }
    }
}