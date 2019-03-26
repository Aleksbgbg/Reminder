namespace Reminder.Services.Interfaces
{
    using System;

    public interface ITimerService
    {
        event EventHandler SecondElapsed;
    }
}