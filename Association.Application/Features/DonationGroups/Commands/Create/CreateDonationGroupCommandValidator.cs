using FluentValidation;

namespace Association.Application.Features.DonationGroups.Commands.Create;
public class CreateDonationGroupCommandValidator : AbstractValidator<CreateDonationGroupCommand>
{
    public CreateDonationGroupCommandValidator()
    {
        RuleFor(d => d.Name).NotEmpty().WithMessage("İsim gereklidir.").MinimumLength(2).WithMessage("En az 2 karakterli olmalıdır.");
    }
}
