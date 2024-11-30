using Association.Application.Features.IntentionTypes.Rules;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Delete;
public class DeleteIntentionTypeCommandHandler(IMapper mapper, IIntentionTypeService intentionTypeService, IntentionTypeBusinessRules intentionTypeBusinessRules) : IRequestHandler<DeleteIntentionTypeCommand, DeletedIntentionTypeResponse>
{
    public async Task<DeletedIntentionTypeResponse> Handle(DeleteIntentionTypeCommand request, CancellationToken cancellationToken)
    {
        IntentionType intentionType = mapper.Map<IntentionType>(request);

        await intentionTypeBusinessRules.CheckIfIntentionTypeIdExistsAsync(intentionType);
        await intentionTypeBusinessRules.CheckIfIntentionTypeHasDonationSharesAsync(intentionType);

        IntentionType deletedIntentionType = await intentionTypeService.DeleteAsync(intentionType);

        return mapper.Map<DeletedIntentionTypeResponse>(deletedIntentionType);
    }
}
