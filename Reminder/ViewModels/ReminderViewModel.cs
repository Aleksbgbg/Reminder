namespace Reminder.ViewModels
{
    using System;

    using Reminder.Models;
    using Reminder.Services.Interfaces;
    using Reminder.ViewModels.Interfaces;

    internal class ReminderViewModel : ViewModelBase, IReminderViewModel
    {
        private readonly IElapsedTimeService _elapsedTimeService;

        public ReminderViewModel(ITimerService timerService, IElapsedTimeService elapsedTimeService, Reminder reminder)
        {
            _elapsedTimeService = elapsedTimeService;
            Reminder = reminder;

            timerService.SecondElapsed += OnSecondElapsed;
        }

        public Reminder Reminder { get; }

        private TimeSpan _remainingTime;
        public TimeSpan RemainingTime
        {
            get => _remainingTime;

            private set
            {
                if (_remainingTime == value) return;

                _remainingTime = value;
                NotifyOfPropertyChange(nameof(RemainingTime));
            }
        }

        private void OnSecondElapsed(object sender, EventArgs e)
        {
            RemainingTime = _elapsedTimeService.TimeLeftToFulfillReminder(Reminder);
        }
    }
}