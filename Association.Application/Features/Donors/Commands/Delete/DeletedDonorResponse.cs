namespace Association.Application.Features.Donors.Commands.Delete;
public record DeletedDonorResponse(
    Guid Id, 
    string Name, 
    string Surname
);
