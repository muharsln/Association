namespace Association.Application.Features.IntentionTypes.Commands.Update;
public record UpdatedIntentionTypeResponse(
    Guid Id,
    string Name,
    bool IsActive
);
