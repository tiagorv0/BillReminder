
using BillReminder.Domain.DTO.Request;
using FluentValidation;

namespace BillReminder.Application.Validation;

public class CategoryRequestValidation : AbstractValidator<CategoryRequest>
{
    public CategoryRequestValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
    }
}
