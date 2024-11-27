using FluentValidation;

namespace Association.Application.Features.IntentionTypes.Commands.Delete;
public class DeleteIntentionTypeCommandValidator : AbstractValidator<DeleteIntentionTypeCommand>
{
    public DeleteIntentionTypeCommandValidator() =>
        RuleFor(d => d.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
