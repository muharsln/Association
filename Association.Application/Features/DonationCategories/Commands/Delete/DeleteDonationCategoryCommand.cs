using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Delete;
public class DeleteDonationCategoryCommand(Guid Id) : IRequest<DeletedDonationCategoryResponse>
{
    public Guid Id { get; init; } = Id;
}
