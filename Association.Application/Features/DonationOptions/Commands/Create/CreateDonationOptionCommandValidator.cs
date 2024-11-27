using FluentValidation;

namespace Association.Application.Features.DonationOptions.Commands.Create;
public class CreateDonationOptionCommandValidator : AbstractValidator<CreateDonationOptionCommand>
{
    public CreateDonationOptionCommandValidator()
    {
        RuleFor(x => x.DonationCategoryId).NotEmpty().WithMessage("Donation Category seçimi zorunludur.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("İsim girmek zorunludur.");
        RuleFor(x => x.Currency).NotEmpty().WithMessage("Para birimi belirtmek zorunludur.");
    }
}
