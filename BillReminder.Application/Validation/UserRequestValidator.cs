
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.Exceptions;
using BillReminder.Domain.Utils;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);

        RuleFor(x => x.Email).NotEmpty().MaximumLength(80).EmailAddress();

        RuleFor(x => x.Password).NotEmpty().Must(x => PasswordChecker.IsValid(x))
            .WithMessage(ValidationMessage.SenhaInvalida);


    }
}
