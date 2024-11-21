using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Delete;
public class DeleteIntentionTypeCommand(Guid id) : IRequest<DeletedIntentionTypeResponse>
{
    public Guid Id { get; set; } = id;
}
