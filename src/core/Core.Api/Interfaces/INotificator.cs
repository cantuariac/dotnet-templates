using Core.Api.Services;

namespace Core.Api.Interfaces
{
    public interface INotificator
    {
        int GetStatusCode();
        void SetStatusCode(int statusCode);
        void Notify(Notification notification);
        void Notify(string message);
        bool CheckNotifications();
        List<Notification> GetNotifications();
    }
}
