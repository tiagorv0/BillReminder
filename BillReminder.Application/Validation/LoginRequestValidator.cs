
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.Exceptions;
using BillReminder.Domain.Utils;
using BillReminder.Infra.Repository.Interfaces;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator(IUserRepository repository)
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(80).EmailAddress();

        RuleFor(x => x.Email).Must(x => repository.ExistByEmailAsync(x).Result)
            .WithMessage(ValidationMessage.UsuarioNaoEncontrado);

        RuleFor(x => x.Password).NotEmpty().Must(x => PasswordChecker.IsValid(x))
            .WithMessage(ValidationMessage.SenhaInvalida);
    }
}
