namespace Association.Application.Features.Donors.Queries.GetById;
public record GetByIdDonorDto(
    Guid Id,
    string Name,
    string Surname,
    string Email,
    string Phone,
    string Location,
    bool IsActive
);
