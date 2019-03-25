namespace Reminder
{
    using Caliburn.Micro.Wrapper;

    using Reminder.ViewModels;
    using Reminder.ViewModels.Interfaces;

    using CM = Caliburn.Micro;

    internal class AppBootstrapper : BootstrapperBase<IShellViewModel>
    {
        protected override void RegisterServices()
        {
            Container.Singleton<CM.IWindowManager, CM.WindowManager>();
        }

        protected override void RegisterViewModels(IViewModelFactory viewModelFactory)
        {
            Container.Singleton<IMainViewModel, MainViewModel>();
        }
    }
}