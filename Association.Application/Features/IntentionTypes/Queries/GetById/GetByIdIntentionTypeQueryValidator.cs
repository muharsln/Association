using FluentValidation;

namespace Association.Application.Features.IntentionTypes.Queries.GetById;
public class GetByIdIntentionTypeQueryValidator : AbstractValidator<GetByIdIntentionTypeQuery>
{
    public GetByIdIntentionTypeQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id değeri boş gönderilemez");
    }
}