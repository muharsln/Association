using MediatR;

namespace Association.Application.Features.DonationOptions.Queries.GetById;
public record GetByIdDonationOptionQuery(Guid Id) : IRequest<GetByIdDonationOptionDto>;
