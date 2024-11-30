using Association.Application.Services.IntentionTypes;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetList;
public class GetListIntentionTypeQueryHandler(IMapper mapper, IIntentionTypeService intentionTypeService) : IRequestHandler<GetListIntentionTypeQuery, IEnumerable<GetListIntentionTypeDto>>
{
    public async Task<IEnumerable<GetListIntentionTypeDto>> Handle(GetListIntentionTypeQuery request, CancellationToken cancellationToken)
    {
        var intentionTypes = await intentionTypeService.GetListAsync();

        return mapper.Map<IEnumerable<GetListIntentionTypeDto>>(intentionTypes);
    }
}
