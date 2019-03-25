namespace Reminder.ViewModels
{
    using System;

    using Caliburn.Micro.Wrapper;

    using Reminder.Models;
    using Reminder.ViewModels.Interfaces;

    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IViewModelFactory viewModelFactory)
        {
            Reminders = new IReminderViewModel[] { viewModelFactory.MakeViewModel<IReminderViewModel>(new Reminder("Todo", TimeSpan.FromDays(3))) };
        }

        public IReminderViewModel[] Reminders { get; }
    }
}