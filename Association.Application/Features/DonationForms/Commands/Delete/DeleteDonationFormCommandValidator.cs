using FluentValidation;

namespace Association.Application.Features.DonationForms.Commands.Delete;
public class DeleteDonationFormCommandValidator : AbstractValidator<DeleteDonationFormCommand>
{
    public DeleteDonationFormCommandValidator() => 
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
