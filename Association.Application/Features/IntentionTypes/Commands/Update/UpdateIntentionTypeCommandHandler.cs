using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Update;

public class UpdateIntentionTypeCommandHandler : IRequestHandler<UpdateIntentionTypeCommand, UpdatedIntentionTypeResponse>
{

    private readonly IIntentionTypeService _intentionTypeService;
    private readonly IMapper _mapper;
    private readonly IntentionTypeBusinessRules _intentionTypeBusinessRules;

    public UpdateIntentionTypeCommandHandler(IIntentionTypeService intentionTypeService, IMapper mapper, IntentionTypeBusinessRules intentionTypeBusinessRules)
    {
        _mapper = mapper;
        _intentionTypeService = intentionTypeService;
        _intentionTypeBusinessRules = intentionTypeBusinessRules;
    }

    public async Task<UpdatedIntentionTypeResponse> Handle(UpdateIntentionTypeCommand request, CancellationToken cancellationToken)
    {
        var intentionType = _mapper.Map<IntentionType>(request);
        await _intentionTypeBusinessRules.CheckIfIntentionTypeIdExists(intentionType);

        intentionType = await _intentionTypeService.GetAsync(d => d.Id == request.Id);

        intentionType.Name = request.Name ?? intentionType.Name;
        intentionType.IsActive = request.IsActive ?? intentionType.IsActive;

        await _intentionTypeBusinessRules.CheckIfIntentionTypeNameExists(intentionType);

        await _intentionTypeService.UpdateAsync(intentionType);

        var response = _mapper.Map<UpdatedIntentionTypeResponse>(intentionType);
        return response;
    }
}
