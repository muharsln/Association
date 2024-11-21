using FluentValidation;

namespace Association.Application.Features.DonationGroups.Commands.Update;

public class UpdateDonationGroupCommandValidator : AbstractValidator<UpdateDonationGroupCommand>
{
    public UpdateDonationGroupCommandValidator()
    {
        RuleFor(d => d.Id).NotEmpty().WithMessage("Grup id değeri boş olamaz");
        RuleFor(d => d.Name).NotEmpty().WithMessage("Grup adı boş olamaz").MinimumLength(2).WithMessage("En az 2 karakterli olmalıdır.");
    }
}
