using MediatR;

namespace Association.Application.Features.DonationForms.Commands.Update;
public record UpdateDonationFormCommand(
    Guid Id,
    Guid? DonorId,
    Guid? DonationCategoryId,
    decimal? TotalPrice
) : IRequest<UpdatedDonationFormResponse>
{
    public Guid Id { get; set; } = Id;
}
