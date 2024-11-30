namespace Association.Application.Features.DonationGroups.Commands.Create;
public record CreatedDonationGroupResponse(
    Guid Id, 
    string Name, 
    bool IsActive
);
