using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Queries.GetById;
public class GetByIdIntentionTypeQueryHandler(IMapper mapper, IntentionTypeBusinessRules intentionTypeBusinessRules, IIntentionTypeService intentionTypeService) : IRequestHandler<GetByIdIntentionTypeQuery, GetByIdIntentionTypeDto>
{
    public async Task<GetByIdIntentionTypeDto> Handle(GetByIdIntentionTypeQuery request, CancellationToken cancellationToken)
    {
        var intentionType = mapper.Map<IntentionType>(request);

        await intentionTypeBusinessRules.CheckIfIntentionTypeIdExistsAsync(intentionType);

        await intentionTypeBusinessRules.CheckIfIntentionTypeNameExistsAsync(intentionType);

        intentionType = await intentionTypeService.GetAsync(p => p.Id == request.Id);

        return mapper.Map<GetByIdIntentionTypeDto>(intentionType);
    }
}
