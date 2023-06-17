
using BillReminder.Domain.DTO.Request;
using BillReminder.Infra.Repository.Interfaces;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class ReminderValidator : AbstractValidator<ReminderRequest>
{
    public ReminderValidator(IReminderRepository repository)
    {
        RuleFor(x => x.IsEnabled).NotEmpty();
        RuleFor(x => x.HowManyDaysToRemind).NotEmpty();
        RuleFor(x => x.HowManyTimes).NotEmpty();
        RuleFor(x => x.BillId).NotEmpty();
        RuleFor(x => x.BillId).Must(x => repository.ExistAsync(x).Result)
            .WithMessage("Conta não existe!");
    }
}
