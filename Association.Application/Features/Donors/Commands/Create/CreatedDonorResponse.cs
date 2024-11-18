namespace Association.Application.Features.Donors.Commands.Create;

public class CreatedDonorResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}