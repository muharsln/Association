using FluentValidation;

namespace Association.Application.Features.DonationCategories.Commands.Update;

public class UpdateDonationCategoryCommandValidator : AbstractValidator<UpdateDonationCategoryCommand>
{
    public UpdateDonationCategoryCommandValidator()
    {
        RuleFor(d => d.Id).NotEmpty().WithMessage("Id değeri boş bırakılamaz");
    }
}