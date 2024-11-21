using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetList;

public class GetListDonationCategoryQuery : IRequest<ICollection<GetListDonationCategoryDto>> { }
