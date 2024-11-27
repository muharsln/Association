using Association.Core.Enums;

namespace Association.Application.Features.DonationOptions.Queries.GetById;
public record GetByIdDonationOptionDto(
    Guid Id,
    Guid DonationCategoryId,
    int Sequence,
    string Name,
    decimal Price,
    bool IsActive,
    Currency Currency
);
