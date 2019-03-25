namespace Reminder.ViewModels
{
    using Reminder.Models;
    using Reminder.ViewModels.Interfaces;

    internal class ReminderViewModel : ViewModelBase, IReminderViewModel
    {
        public ReminderViewModel(Reminder reminder)
        {
            Reminder = reminder;
        }

        public Reminder Reminder { get; }
    }
}