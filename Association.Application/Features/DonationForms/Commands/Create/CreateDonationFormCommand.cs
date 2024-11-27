using MediatR;

namespace Association.Application.Features.DonationForms.Commands.Create;
public record CreateDonationFormCommand(Guid DonorId, Guid DonationCategoryId, decimal TotalPrice, DateTime CreateDate) : IRequest<CreatedDonationFormResponse>
{
    public CreateDonationFormCommand() : this(default, default, 0, DateTime.Now) { }
}
