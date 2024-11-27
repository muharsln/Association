using MediatR;

namespace Association.Application.Features.IntentionTypes.Commands.Delete;
public record DeleteIntentionTypeCommand(Guid Id) : IRequest<DeletedIntentionTypeResponse>;
