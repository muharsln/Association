using MediatR;

namespace Association.Application.Features.DonationShares.Commands.Create;
public record CreateDonationShareCommand(
    Guid DonationFormId,
    Guid DonationOptionId,
    Guid IntentionTypeId,
    string FirstName,
    string LastName,
    string Phone,
    decimal? ShareAmount
) : IRequest<CreatedDonationShareResponse>;
