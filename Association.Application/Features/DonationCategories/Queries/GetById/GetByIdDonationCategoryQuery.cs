using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetById;
public record GetByIdDonationCategoryQuery(Guid Id) : IRequest<GetByIdDonationCategoryDto>;
