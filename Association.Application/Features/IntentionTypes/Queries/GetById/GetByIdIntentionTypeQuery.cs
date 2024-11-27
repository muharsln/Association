using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetById;
public record GetByIdIntentionTypeQuery(Guid Id) : IRequest<GetByIdIntentionTypeDto>;
