using MediatR;

namespace Association.Application.Features.Donors.Commands.Update;
public record UpdateDonorCommand(
    Guid Id,
    string? Name,
    string? Surname,
    string? Email,
    string? Phone,
    string? Location,
    bool? IsActive
) : IRequest<UpdatedDonorResponse>
{
    public Guid Id { get; set; }
}
