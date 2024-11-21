namespace Association.Application.Features.DonationGroups.Queries.GetList;
public record GetListDonationGroupDto(
    Guid Id,
    string Name,
    bool IsActive);
