using Association.Core.Enums;

namespace Association.Application.Features.DonationOptions.Commands.Update;
public record UpdatedDonationOptionResponse(
    Guid Id,
    Guid DonationCategoryId,
    int Sequence,
    string Name,
    decimal Price,
    bool IsActive,
    Currency Currency
);
