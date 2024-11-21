using FluentValidation;

namespace Association.Application.Features.DonationCategories.Commands.Delete;

public class DeleteDonationCategoryCommandValidator : AbstractValidator<DeleteDonationCategoryCommand>
{
    public DeleteDonationCategoryCommandValidator()
    {
        RuleFor(d => d.Id).NotEmpty().WithMessage("Id alanı boş olamaz.");
    }
}