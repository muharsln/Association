using MediatR;

namespace Association.Application.Features.Donors.Commands.Delete;
public class DeleteDonorCommand(Guid id) : IRequest<DeletedDonorResponse>
{
    public Guid Id { get; set; } = id;
}