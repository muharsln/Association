using MediatR;

namespace Association.Application.Features.Donors.Commands.Delete;
public record DeleteDonorCommand(Guid id) : IRequest<DeletedDonorResponse>
{
    public Guid Id { get; init; }
}
