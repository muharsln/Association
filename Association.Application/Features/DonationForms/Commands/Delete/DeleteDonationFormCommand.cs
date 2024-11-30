using MediatR;

namespace Association.Application.Features.DonationForms.Commands.Delete;
public record DeleteDonationFormCommand(Guid Id) : IRequest<DeletedDonationFormResponse>
{
    public Guid Id { get; init; } = Id;
}
