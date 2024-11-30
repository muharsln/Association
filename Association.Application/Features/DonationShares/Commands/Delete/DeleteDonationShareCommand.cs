using MediatR;

namespace Association.Application.Features.DonationShares.Commands.Delete;
public record DeleteDonationShareCommand(Guid Id) : IRequest<DeletedDonationShareResponse>;
