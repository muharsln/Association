namespace Association.Application.Features.DonationShares.Commands.Update;

public record UpdatedDonationShareResponse(
Guid Id,
Guid DonationFormId,
Guid DonationOptionId,
Guid IntentionTypeId,
string FirstName,
string LastName,
string Phone,
decimal ShareAmount
);
