namespace Association.Application.Features.DonationCategories.Queries.GetList;
public record GetListDonationCategoryDto(
    Guid Id,
    Guid DonationGroupId,
    string Name,
    bool IsActive
);
