namespace Reminder.ViewModels.Interfaces
{
    internal interface IShellViewModel : IViewModelBase
    {
        IMainViewModel MainViewModel { get; }
    }
}