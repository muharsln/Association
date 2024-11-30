using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Create;
public class CreateIntentionTypeCommandHandler(IMapper mapper, IIntentionTypeService intentionTypeService, IntentionTypeBusinessRules intentionTypeBusinessRules) : IRequestHandler<CreateIntentionTypeCommand, CreatedIntentionTypeResponse>
{
    public async Task<CreatedIntentionTypeResponse> Handle(CreateIntentionTypeCommand request, CancellationToken cancellationToken)
    {
        var intentionType = mapper.Map<IntentionType>(request);

        await intentionTypeBusinessRules.CheckIfIntentionTypeNameExistsAsync(intentionType);

        var addedIntentionType = await intentionTypeService.AddAsync(intentionType);

        return mapper.Map<CreatedIntentionTypeResponse>(addedIntentionType);
    }
}
