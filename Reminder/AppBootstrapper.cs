namespace Reminder
{
    using Caliburn.Micro.Wrapper;

    using Reminder.ViewModels;
    using Reminder.ViewModels.Interfaces;

    internal class AppBootstrapper : BootstrapperBase<IShellViewModel>
    {
        protected override void RegisterViewModels(IViewModelFactory viewModelFactory)
        {
            Container.Singleton<IShellViewModel, ShellViewModel>();
            Container.Singleton<IMainViewModel, MainViewModel>();

            viewModelFactory.Register<IReminderViewModel, ReminderViewModel>();
        }
    }
}