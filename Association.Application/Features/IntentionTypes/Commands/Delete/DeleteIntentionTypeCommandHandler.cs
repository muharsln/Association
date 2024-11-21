using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Delete;

public class DeleteIntentionTypeCommandHandler : IRequestHandler<DeleteIntentionTypeCommand, DeletedIntentionTypeResponse>
{
    private readonly IMapper _mapper;
    private readonly IIntentionTypeService _intentionTypeService;
    private readonly IntentionTypeBusinessRules _intentionTypeBusinessRules;

    public DeleteIntentionTypeCommandHandler(IMapper mapper, IIntentionTypeService intentionTypeService, IntentionTypeBusinessRules intentionTypeBusinessRules)
    {
        _mapper = mapper;
        _intentionTypeService = intentionTypeService;
        _intentionTypeBusinessRules = intentionTypeBusinessRules;
    }

    public async Task<DeletedIntentionTypeResponse> Handle(DeleteIntentionTypeCommand request, CancellationToken cancellationToken)
    {
        IntentionType intentionType = _mapper.Map<IntentionType>(request);

        await _intentionTypeBusinessRules.CheckIfIntentionTypeIdExists(intentionType);
        await _intentionTypeBusinessRules.CheckIfIntentionTypeHasDonationShares(intentionType);

        IntentionType deletedIntentionType = await _intentionTypeService.DeleteAsync(intentionType);

        var response = _mapper.Map<DeletedIntentionTypeResponse>(deletedIntentionType);

        return response;
    }
}
