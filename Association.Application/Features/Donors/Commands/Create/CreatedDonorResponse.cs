namespace Association.Application.Features.Donors.Commands.Create;
public record CreatedDonorResponse(
    Guid Id, 
    string Name, 
    string Surname
);
