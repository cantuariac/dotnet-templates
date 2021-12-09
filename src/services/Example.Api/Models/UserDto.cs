using Core.Business.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace ExampleApi.Models
{
    public class UserDto : IValidatable
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ValidationResult Validate()
        {
            return new UserDtoValidator().Validate(this);
        }
    }
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Matches("\b[0-9a-zA-Z]+\b");

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
