namespace Association.Application.Features.DonationShares.Queries.GetById;
public record GetByIdDonationShareDto(
    Guid Id,
    Guid DonationFormId,
    Guid DonationOptionId,
    Guid IntentionTypeId,
    string FirstName,
    string LastName,
    string Phone,
    decimal ShareAmount
);
