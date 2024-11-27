using Association.Application.Constants;
using FluentValidation;

namespace Association.Application.Features.DonationForms.Commands.Create;
public class CreateDonationFormCommandValidator : AbstractValidator<CreateDonationFormCommand>
{
    public CreateDonationFormCommandValidator()
    {
        RuleFor(x => x.DonorId)
            .NotEmpty().WithMessage(ValidationMessages.DonorSelectionRequired);
        RuleFor(x => x.DonationCategoryId)
            .NotEmpty().WithMessage(ValidationMessages.DonationCategorySelectionRequired);
    }
}
