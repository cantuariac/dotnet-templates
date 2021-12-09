using Core.Business.Interfaces;
using FluentValidation;

namespace Core.Business
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;
        private int StatusCode;

        public Notificator()
        {
            _notifications = new List<Notification>();
            StatusCode = 400;
        }
        public int GetStatusCode()
        {
            return StatusCode;
        }
        public void SetStatusCode(int statusCode)
        {
            StatusCode = statusCode;
        }
        public void Notify(Notification notification)
        {
            _notifications.Add(notification);
        }
        public void Notify(string message)
        {
            _notifications.Add(new Notification(message));
        }
        public bool CheckNotifications() 
        {
            return _notifications.Any();
        }
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }
        protected bool Validate<TValidator, TEntity>(TValidator validator, TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            var result = validator.Validate(entity);

            if (result.IsValid)
            {
                return true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Notify(error.ErrorMessage);
                }
                return false;
            }
        }
    }
}