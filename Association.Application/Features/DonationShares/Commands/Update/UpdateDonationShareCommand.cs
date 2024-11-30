using MediatR;

namespace Association.Application.Features.DonationShares.Commands.Update;
public record UpdateDonationShareCommand(
    Guid Id,
    Guid? DonationFormId,
    Guid? DonationOptionId,
    Guid? IntentionTypeId,
    string? FirstName,
    string? LastName,
    string? Phone,
    decimal? ShareAmount
) : IRequest<UpdatedDonationShareResponse>
{
    public Guid Id { get; set; } = Id;
}
