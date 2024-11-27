using MediatR;

namespace Association.Application.Features.DonationForms.Queries.GetList;
public record GetListDonationFormQuery() : IRequest<ICollection<GetListDonationFormDto>>;
