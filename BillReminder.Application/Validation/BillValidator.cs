
using BillReminder.Domain.DTO.Request;
using BillReminder.Infra.Repository.Interfaces;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class BillValidator : AbstractValidator<BillRequest>
{
    public BillValidator(IAccountRepository accountRepository, ICategoryRepository categoryRepository)
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);

        RuleFor(x => x.Value).NotEmpty().GreaterThan(0);

        RuleFor(x => x.Status).NotEmpty().IsInEnum();

        RuleFor(x => x.ReferenceMonth).NotEmpty().IsInEnum();

        RuleFor(x => x.ExpireDate).NotEmpty();

        RuleFor(x => x.Comment).MaximumLength(100);

        RuleFor(x => x.AccountId).NotEmpty();
        RuleFor(x => x.AccountId).Must(x => accountRepository.ExistAsync(x).Result)
            .WithMessage("Conta não existe!");

        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.CategoryId).Must(x => categoryRepository.ExistAsync(x).Result)
            .WithMessage("Categoria não existe");
    }
}
