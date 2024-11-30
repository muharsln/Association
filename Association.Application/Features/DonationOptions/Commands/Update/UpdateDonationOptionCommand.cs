using Association.Core.Enums;
using MediatR;

namespace Association.Application.Features.DonationOptions.Commands.Update;
public record UpdateDonationOptionCommand(
    Guid Id,
    Guid? DonationCategoryId,
    int? Sequence,
    string? Name,
    decimal? Price,
    bool? IsActive,
    Currency? Currency
) : IRequest<UpdatedDonationOptionResponse>
{
    public Guid Id { get; set; } = Id;
}
