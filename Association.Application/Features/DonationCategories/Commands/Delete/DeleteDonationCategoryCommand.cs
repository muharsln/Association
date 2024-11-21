using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Delete;
public class DeleteDonationCategoryCommand(Guid id) : IRequest<DeletedDonationCategoryResponse>
{
    public Guid Id { get; set; } = id;
}
