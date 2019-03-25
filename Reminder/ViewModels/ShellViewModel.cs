namespace Reminder.ViewModels
{
    using Reminder.ViewModels.Interfaces;

    internal sealed class ShellViewModel : ViewModelBase, IShellViewModel
    {
        public ShellViewModel(IMainViewModel mainViewModel)
        {
            DisplayName = "Reminder";

            MainViewModel = mainViewModel;
        }

        public IMainViewModel MainViewModel { get; }
    }
}