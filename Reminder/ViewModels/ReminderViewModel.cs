namespace Reminder.ViewModels
{
    using System;

    using Reminder.Models;
    using Reminder.Services.Interfaces;
    using Reminder.ViewModels.Interfaces;

    internal class ReminderViewModel : ViewModelBase, IReminderViewModel
    {
        private readonly ITimerService _timerService;

        private readonly IElapsedTimeService _elapsedTimeService;

        public ReminderViewModel(ITimerService timerService, IElapsedTimeService elapsedTimeService, Reminder reminder)
        {
            _timerService = timerService;
            _elapsedTimeService = elapsedTimeService;
            Reminder = reminder;

            SubscribeTimerSecondElapsed();
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

        private void OnTimerSecondElapsed(object sender, EventArgs e)
        {
            if (_elapsedTimeService.IsExpired(Reminder))
            {
                ExpireReminder();
            }
            else
            {
                CalculateRemainingTime();
            }
        }

        private void ExpireReminder()
        {
            Reminder.Expired = true;
            UnsubscribeTimerSecondElapsed();
        }

        private void CalculateRemainingTime()
        {
            RemainingTime = _elapsedTimeService.TimeLeftToFulfillReminder(Reminder);
        }

        private void SubscribeTimerSecondElapsed()
        {
            _timerService.SecondElapsed += OnTimerSecondElapsed;
        }

        private void UnsubscribeTimerSecondElapsed()
        {
            _timerService.SecondElapsed -= OnTimerSecondElapsed;
        }
    }
}