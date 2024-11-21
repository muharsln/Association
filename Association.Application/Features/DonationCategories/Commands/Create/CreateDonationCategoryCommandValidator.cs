using FluentValidation;

namespace Association.Application.Features.DonationCategories.Commands.Create;

public class CreateDonationCategoryCommandValidator : AbstractValidator<CreateDonationCategoryCommand>
{
    public CreateDonationCategoryCommandValidator()
    {
        RuleFor(d => d.Name)
            .NotEmpty().WithMessage("Bağış kategorisi adı boş olamaz.")
            .MinimumLength(2).WithMessage("Minimum 2 karakter olmalıdır");
        RuleFor(d => d.DonationGroupId)
            .NotEmpty().WithMessage("Bağış grubu id boş olamaz.");
    }
}