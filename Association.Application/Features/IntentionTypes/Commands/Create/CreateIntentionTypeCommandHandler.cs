using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Create;

public class CreateIntentionTypeCommandHandler : IRequestHandler<CreateIntentionTypeCommand, CreatedIntentionTypeResponse>
{

    private readonly IMapper _mapper;
    private readonly IIntentionTypeService _intentionTypeService;
    private readonly IntentionTypeBusinessRules _intentionTypeBusinessRules;

    public CreateIntentionTypeCommandHandler(IMapper mapper, IIntentionTypeService intentionTypeService, IntentionTypeBusinessRules intentionTypeBusinessRules)
    {
        _mapper = mapper;
        _intentionTypeService = intentionTypeService;
        _intentionTypeBusinessRules = intentionTypeBusinessRules;
    }

    public async Task<CreatedIntentionTypeResponse> Handle(CreateIntentionTypeCommand request, CancellationToken cancellationToken)
    {
        var intentionType = _mapper.Map<IntentionType>(request);

        await _intentionTypeBusinessRules.CheckIfIntentionTypeNameExists(intentionType);

        var addedIntentionType = await _intentionTypeService.AddAsync(intentionType);

        var response = _mapper.Map<CreatedIntentionTypeResponse>(addedIntentionType);

        return response;
    }
}