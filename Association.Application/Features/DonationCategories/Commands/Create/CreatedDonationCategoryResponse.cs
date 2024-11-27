namespace Association.Application.Features.DonationCategories.Commands.Create;

public record CreatedDonationCategoryResponse(
    Guid Id, 
    Guid DonationGroupId, 
    string Name, 
    bool IsActive
);
