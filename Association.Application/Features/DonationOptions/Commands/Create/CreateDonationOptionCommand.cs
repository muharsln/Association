using Association.Core.Enums;
using MediatR;

namespace Association.Application.Features.DonationOptions.Commands.Create;
public record CreateDonationOptionCommand(Guid DonationCategoryId, int Sequence, string Name, decimal Price, bool IsActive, Currency Currency) : IRequest<CreatedDonationOptionResponse>
{
    public CreateDonationOptionCommand() : this(default, 0, default, 0, true, default) { }
}
