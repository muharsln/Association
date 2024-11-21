using FluentValidation;

namespace Association.Application.Features.IntentionTypes.Commands.Delete;

public class DeleteIntentionTypeCommandValidator : AbstractValidator<DeleteIntentionTypeCommand>
{
    public DeleteIntentionTypeCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id değeri girmek zorunludur.");
    }
}