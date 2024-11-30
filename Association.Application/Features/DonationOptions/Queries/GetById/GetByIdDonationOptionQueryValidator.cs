using FluentValidation;

namespace Association.Application.Features.DonationOptions.Queries.GetById;
public class GetByIdDonationOptionQueryValidator : AbstractValidator<GetByIdDonationOptionQuery>
{
    public GetByIdDonationOptionQueryValidator()
    {
        RuleFor(d => d.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
    }
}
