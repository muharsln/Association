using FluentValidation;

namespace Association.Application.Features.DonationShares.Commands.Update;
public class UpdateDonationShareCommandValidator : AbstractValidator<UpdateDonationShareCommand>
{
    public UpdateDonationShareCommandValidator()
    {
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
    }
}
