using System;
using System.Collections.Generic;

namespace Core.Business.Interfaces
{
    public interface INotificator
    {
        void Notify(Notification notification);
        List<Notification> GetNotifications();
        bool CheckNotifications();
    }
}
