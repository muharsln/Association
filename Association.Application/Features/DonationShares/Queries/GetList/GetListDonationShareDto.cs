namespace Association.Application.Features.DonationShares.Queries.GetList;
public record GetListDonationShareDto(
    Guid Id,
    Guid DonationFormId,
    Guid DonationOptionId,
    Guid IntentionTypeId,
    string FirstName,
    string LastName,
    string Phone,
    decimal ShareAmount
);
