using BillReminder.Domain.DTO.Request;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class ReminderValidator : AbstractValidator<ReminderRequest>
{
    public ReminderValidator()
    {
        RuleFor(x => x.IsEnabled).NotEmpty();
        RuleFor(x => x.HowManyDaysToRemind).NotEmpty();
        RuleFor(x => x.HowManyTimes).NotEmpty();
    }
}
