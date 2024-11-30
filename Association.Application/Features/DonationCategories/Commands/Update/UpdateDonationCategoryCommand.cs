using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Update;
public record UpdateDonationCategoryCommand(
    Guid Id,
    Guid? DonationGroupId,
    string? Name,
    bool? IsActive
) : IRequest<UpdatedDonationCategoryResponse>
{
    public Guid Id { get; set; } = Id;
}
