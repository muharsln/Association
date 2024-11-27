using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Create;
public record CreateDonationCategoryCommand(Guid DonationGroupId, string Name, bool IsActive) : IRequest<CreatedDonationCategoryResponse>
{
    public CreateDonationCategoryCommand() : this(default, string.Empty, true) { }
}
