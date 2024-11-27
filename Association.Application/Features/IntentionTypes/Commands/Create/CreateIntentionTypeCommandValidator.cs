using FluentValidation;

namespace Association.Application.Features.IntentionTypes.Commands.Create;
public class CreateIntentionTypeCommandValidator : AbstractValidator<CreateIntentionTypeCommand>
{
    public CreateIntentionTypeCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("İsim değeri boş olamaz.")
            .MinimumLength(2).WithMessage("En az 2 karakterli bir giriş yapınız");
    }
}
