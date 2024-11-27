using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetList;
public record GetListDonationCategoryQuery() : IRequest<ICollection<GetListDonationCategoryDto>>;
