using FluentValidation;

namespace Association.Application.Features.DonationOptions.Commands.Update;
public class UpdateDonationOptionCommandValidator : AbstractValidator<UpdateDonationOptionCommand>
{
    public UpdateDonationOptionCommandValidator() =>
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("Id değeri boş olmamalıdır")
        .NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
