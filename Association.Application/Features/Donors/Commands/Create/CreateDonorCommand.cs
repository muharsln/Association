using MediatR;

namespace Association.Application.Features.Donors.Commands.Create;
public class CreateDonorCommand : IRequest<CreatedDonorResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }
    public string? Location { get; set; }
    public bool IsActive { get; set; }

    public CreateDonorCommand()
    {
        Name = string.Empty;
        Surname = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Location = string.Empty;
        IsActive = true;
    }

    public CreateDonorCommand(string name, string surname, string email, string phone, string location, bool isActive)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
        Location = location;
        IsActive = isActive;
    }
}