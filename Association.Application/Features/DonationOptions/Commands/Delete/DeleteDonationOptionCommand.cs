using MediatR;

namespace Association.Application.Features.DonationOptions.Commands.Delete;
public record DeleteDonationOptionCommand(Guid Id) : IRequest<DeletedDonationOptionResponse>;
