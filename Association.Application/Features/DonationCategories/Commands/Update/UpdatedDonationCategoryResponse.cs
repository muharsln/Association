namespace Association.Application.Features.DonationCategories.Commands.Update;

public class UpdatedDonationCategoryResponse
{
    public Guid Id { get; set; }
    public Guid DonationGroupId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
