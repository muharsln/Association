using Association.Application.Services.IntentionTypes;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetList;

public class GetListIntentionTypeQueryHandler : IRequestHandler<GetListIntentionTypeQuery, IEnumerable<GetListIntentionTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly IIntentionTypeService _intentionTypeService;

    public GetListIntentionTypeQueryHandler(IMapper mapper, IIntentionTypeService intentionTypeService)
    {
        _mapper = mapper;
        _intentionTypeService = intentionTypeService;
    }

    public async Task<IEnumerable<GetListIntentionTypeDto>> Handle(GetListIntentionTypeQuery request, CancellationToken cancellationToken)
    {
        var intentionTypes = await _intentionTypeService.GetListAsync();

        return _mapper.Map<IEnumerable<GetListIntentionTypeDto>>(intentionTypes);
    }
}

