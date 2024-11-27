using MediatR;

namespace Association.Application.Features.DonationOptions.Queries.GetList;
public record GetListDonationOptionQuery : IRequest<ICollection<GetListDonationOptionDto>>;
