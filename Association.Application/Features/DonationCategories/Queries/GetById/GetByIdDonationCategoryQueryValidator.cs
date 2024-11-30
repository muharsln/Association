using FluentValidation;

namespace Association.Application.Features.DonationCategories.Queries.GetById;
public class GetByIdDonationCategoryQueryValidator : AbstractValidator<GetByIdDonationCategoryQuery>
{
    public GetByIdDonationCategoryQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id değeri zorunludur. ")
            .NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz.");
    }
}
