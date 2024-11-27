using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetList;
public record GetListIntentionTypeQuery() : IRequest<IEnumerable<GetListIntentionTypeDto>>;
