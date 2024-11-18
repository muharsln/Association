namespace Association.Application.Features.Donors.Queries.GetList;

public class GetListDonorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
}