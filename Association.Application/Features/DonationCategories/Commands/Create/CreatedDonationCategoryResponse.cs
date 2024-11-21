namespace Association.Application.Features.DonationCategories.Commands.Create;

public class CreatedDonationCategoryResponse
{
    public Guid Id { get; set; }
    public Guid DonationGroupId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}