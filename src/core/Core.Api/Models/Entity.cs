using FluentValidation.Results;

namespace Core.Api.Models
{
    public abstract class Entity<IdType> where IdType : IComparable
    {
        public IdType Id { get; set; }

        public virtual ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
