using FluentValidation;

namespace Association.Application.Features.DonationGroups.Queries.GetById;

public class GetByIdDonationGroupQueryValidator : AbstractValidator<GetByIdDonationGroupQuery>
{
    public GetByIdDonationGroupQueryValidator()
    {
        RuleFor(d => d.Id).NotEmpty();
    }
}