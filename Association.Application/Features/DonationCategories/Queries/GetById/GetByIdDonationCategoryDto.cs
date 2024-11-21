namespace Association.Application.Features.DonationCategories.Queries.GetById;
public record GetByIdDonationCategoryDto(
    Guid Id,
    Guid DonationGroupId,
    string Name,
    bool IsActive
);
