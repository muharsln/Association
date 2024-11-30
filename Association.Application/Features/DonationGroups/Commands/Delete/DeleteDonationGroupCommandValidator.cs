using FluentValidation;

namespace Association.Application.Features.DonationGroups.Commands.Delete;
public class DeleteDonationGroupCommandValidator : AbstractValidator<DeleteDonationGroupCommand>
{
    public DeleteDonationGroupCommandValidator() =>
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
