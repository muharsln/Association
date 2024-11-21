using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetById;

public class GetByIdDonationCategoryQuery(Guid id) : IRequest<GetByIdDonationCategoryDto>
{
    public Guid Id { get; set; } = id;
}
