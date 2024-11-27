using MediatR;

namespace Association.Application.Features.DonationForms.Queries.GetById;
public record GetByIdDonationFormQuery(Guid id) : IRequest<GetByIdDonationFormDto>;
