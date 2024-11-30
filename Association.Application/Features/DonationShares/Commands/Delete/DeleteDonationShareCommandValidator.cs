using FluentValidation;

namespace Association.Application.Features.DonationShares.Commands.Delete;
public class DeleteDonationShareCommandValidator : AbstractValidator<DeleteDonationShareCommand>
{
    public DeleteDonationShareCommandValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty().WithMessage("Id değeri boş olamaz")
            .NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
    }
}
