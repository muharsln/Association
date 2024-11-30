using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Update;
public class UpdateIntentionTypeCommandHandler(IIntentionTypeService intentionTypeService, IMapper mapper, IntentionTypeBusinessRules intentionTypeBusinessRules) : IRequestHandler<UpdateIntentionTypeCommand, UpdatedIntentionTypeResponse>
{
    public async Task<UpdatedIntentionTypeResponse> Handle(UpdateIntentionTypeCommand request, CancellationToken cancellationToken)
    {
        var intentionType = mapper.Map<IntentionType>(request);
        await intentionTypeBusinessRules.CheckIfIntentionTypeIdExistsAsync(intentionType);

        intentionType = await intentionTypeService.GetAsync(d => d.Id == request.Id);

        intentionType.Name = request.Name ?? intentionType.Name;
        intentionType.IsActive = request.IsActive ?? intentionType.IsActive;

        await intentionTypeBusinessRules.CheckIfIntentionTypeNameExistsAsync(intentionType);

        await intentionTypeService.UpdateAsync(intentionType);

        return mapper.Map<UpdatedIntentionTypeResponse>(intentionType);
    }
}
