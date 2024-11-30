using FluentValidation;

namespace Association.Application.Features.DonationShares.Queries.GetById;
public class GetByIdDonationShareQueryValidator : AbstractValidator<GetByIdDonationShareQuery>
{
    public GetByIdDonationShareQueryValidator()
    {
        RuleFor(d => d.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
    }
}
