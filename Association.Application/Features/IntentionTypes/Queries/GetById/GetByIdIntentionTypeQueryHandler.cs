using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetById;

public class GetByIdIntentionTypeQueryHandler : IRequestHandler<GetByIdIntentionTypeQuery, GetByIdIntentionTypeDto>
{
    private readonly IIntentionTypeService _intentionTypeService;
    private readonly IMapper _mapper;
    private readonly IntentionTypeBusinessRules _intentionTypeBusinessRules;

    public GetByIdIntentionTypeQueryHandler(IMapper mapper, IntentionTypeBusinessRules intentionTypeBusinessRules, IIntentionTypeService intentionTypeService)
    {
        _mapper = mapper;
        _intentionTypeBusinessRules = intentionTypeBusinessRules;
        _intentionTypeService = intentionTypeService;
    }

    public async Task<GetByIdIntentionTypeDto> Handle(GetByIdIntentionTypeQuery request, CancellationToken cancellationToken)
    {
        var intentionType = _mapper.Map<IntentionType>(request);

        await _intentionTypeBusinessRules.CheckIfIntentionTypeIdExists(intentionType);

        await _intentionTypeBusinessRules.CheckIfIntentionTypeNameExists(intentionType);

        intentionType = await _intentionTypeService.GetAsync(p => p.Id == request.Id);

        return _mapper.Map<GetByIdIntentionTypeDto>(intentionType);
    }
}
