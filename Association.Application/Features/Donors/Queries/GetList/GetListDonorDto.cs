namespace Association.Application.Features.Donors.Queries.GetList;
public record GetListDonorDto(
    Guid Id, 
    string Name, 
    string Surname, 
    string Email, 
    string Phone, 
    string Location, 
    bool IsActive
);
