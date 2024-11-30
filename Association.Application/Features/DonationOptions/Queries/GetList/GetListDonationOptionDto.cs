using Association.Core.Enums;

namespace Association.Application.Features.DonationOptions.Queries.GetList;
public record GetListDonationOptionDto(
    Guid Id,
    Guid DonationCategoryId,
    int Sequence,
    string Name,
    decimal Price,
    bool IsActive,
    Currency Currency
);
