using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Update;
public record UpdateIntentionTypeCommand(
    Guid Id,
    string? Name,
    bool? IsActive
) : IRequest<UpdatedIntentionTypeResponse>
{
    public Guid Id { get; set; } = Id;
};
