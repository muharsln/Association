using MediatR;

namespace Association.Application.Features.Donors.Commands.Create;
public record CreateDonorCommand(
    string Name, 
    string Surname, 
    string? Email, 
    string Phone, 
    string? Location, 
    bool IsActive
) : IRequest<CreatedDonorResponse>
{
    public CreateDonorCommand() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true) { }
}
