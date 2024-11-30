namespace Association.Application.Features.DonationShares.Commands.Create;
public record CreatedDonationShareResponse(
    Guid DonationFormId,
    Guid DonationOptionId,
    Guid IntentionTypeId,
    string FirstName,
    string LastName,
    string Phone,
    decimal ShareAmount
);
