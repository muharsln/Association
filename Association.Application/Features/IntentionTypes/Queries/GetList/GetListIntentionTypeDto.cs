namespace Association.Application.Features.IntentionTypes.Queries.GetList;
public record GetListIntentionTypeDto(
    Guid Id,
    string Name,
    bool IsActive
);