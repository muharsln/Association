using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetById;

public class GetByIdIntentionTypeQuery(Guid id) : IRequest<GetByIdIntentionTypeDto>
{
    public Guid Id { get; set; } = id;
}
