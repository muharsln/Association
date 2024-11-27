namespace Association.Application.Features.DonationGroups.Queries.GetById;
public record GetByIdDonationGroupDto(
    Guid Id,
    string Name,
    bool IsActive
);
