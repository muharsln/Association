using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Create;
public record CreateIntentionTypeCommand(string Name, bool IsActive) : IRequest<CreatedIntentionTypeResponse>
{
    public CreateIntentionTypeCommand() : this(string.Empty, true) { }
}
