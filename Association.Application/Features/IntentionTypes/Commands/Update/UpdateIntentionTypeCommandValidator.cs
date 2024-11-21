using FluentValidation;

namespace Association.Application.Features.IntentionTypes.Commands.Update;

public class UpdateIntentionTypeCommandValidator : AbstractValidator<UpdateIntentionTypeCommand>
{
    public UpdateIntentionTypeCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id değeri boş gönderilemez");
    }
}