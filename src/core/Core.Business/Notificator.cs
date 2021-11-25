using Core.Business.Interfaces;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Business
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public bool CheckNotifications()
        {
            return _notifications.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }


        protected void Notify(string message)
        {
            _notifications.Add(new Notification(message));
        }

        protected void Notify(string message, string label)
        {
            _notifications.Add(new Notification(message, label));
        }
        public void Notify(Notification notification)
        {
            _notifications.Add(notification);
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