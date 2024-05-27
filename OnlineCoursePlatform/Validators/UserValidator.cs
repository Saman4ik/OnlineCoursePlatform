using FluentValidation;
using OnlineCoursePlatform.Modellar;

namespace OnlineCoursePlatform.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.PasswordHash).NotEmpty();
    }
}
