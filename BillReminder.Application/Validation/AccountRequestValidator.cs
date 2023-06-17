
using BillReminder.Domain.DTO.Request;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class AccountRequestValidatior : AbstractValidator<AccountRequest>
{
    public AccountRequestValidatior()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
    }
}
