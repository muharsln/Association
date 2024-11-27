namespace Association.Application.Features.DonationCategories.Commands.Update;

public record UpdatedDonationCategoryResponse(
    Guid Id, 
    Guid DonationGroupId, 
    string Name, 
    bool IsActive
);
