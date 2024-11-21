namespace Association.Application.Features.DonationGroups.Commands.Create;

public class CreatedDonationGroupResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}