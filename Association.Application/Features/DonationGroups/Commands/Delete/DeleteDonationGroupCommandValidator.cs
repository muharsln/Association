using FluentValidation;

namespace Association.Application.Features.DonationGroups.Commands.Delete;

public class DeleteDonationGroupCommandValidator : AbstractValidator<DeleteDonationGroupCommand>
{
    public DeleteDonationGroupCommandValidator()
    {
        RuleFor(d => d.Id).NotEmpty().WithMessage("Id değeri boş olamaz");
    }
}
