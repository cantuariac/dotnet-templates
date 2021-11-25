
using Core.Business.Interfaces;
using FluentValidation;

namespace Core.Business
{
    public abstract class CoreService
    {
        protected readonly INotificator _notificator;

        protected CoreService(INotificator notificator)
        {
            _notificator = notificator;
        }

        //protected bool Validate<TValidator, TEntity>(TValidator validator, TEntity entity) where TValidator : AbstractValidator<TEntity>
        //{
        //    var result = validator.Validate(entity);

        //    if (result.IsValid)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            Notify(error.ErrorMessage);
        //        }
        //        return false;
        //    }
        //}

        //protected void Notify(string message)
        //{
        //    _notificator.Notify(new Notification(message));
        //}

        //protected void Notify(string message, string label)
        //{
        //    _notificator.Notify(new Notification(message, label));
        //}
    }
}