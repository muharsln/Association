using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetList;

public class GetListIntentionTypeQuery : IRequest<IEnumerable<GetListIntentionTypeDto>>
{
}

