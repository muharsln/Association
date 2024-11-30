using FluentValidation;

namespace Association.Application.Features.DonationOptions.Commands.Delete;
public class DeleteDonationOptionCommandValidator : AbstractValidator<DeleteDonationOptionCommand>
{
    public DeleteDonationOptionCommandValidator() => 
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
