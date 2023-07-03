
using BillReminder.Domain.DTO.Request;
using BillReminder.Infra.Repository.Interfaces;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class CategoryRequestValidation : AbstractValidator<CategoryRequest>
{
    public CategoryRequestValidation(IAccountRepository accountRepository)
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        RuleFor(x => x.AccountId).NotEmpty()
            .Must(x => accountRepository.ExistAsync(x).Result)
            .WithMessage("Conta não existe!");
    }
}
