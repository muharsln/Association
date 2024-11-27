using Association.Application.Constants;
using FluentValidation;

namespace Association.Application.Features.Donors.Commands.Create;
public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
{
    public CreateDonorCommandValidator()
    {
        RuleFor(d => d.Name)
            .NotEmpty().WithMessage(string.Format(ValidationMessages.RequiredField, "İsim"))
            .MinimumLength(2).WithMessage(ValidationMessages.MinLength);

        RuleFor(d => d.Surname)
            .NotEmpty().WithMessage(string.Format(ValidationMessages.RequiredField, "Soyisim"))
            .MinimumLength(2).WithMessage(ValidationMessages.MinLength);

        RuleFor(d => d.Email)
            .EmailAddress().When(d => !string.IsNullOrEmpty(d.Email)).WithMessage(ValidationMessages.EmailInvalid);

        RuleFor(d => d.Phone)
            .NotEmpty().WithMessage(string.Format(ValidationMessages.RequiredField, "Telefon"))
            .Length(10, 10).WithMessage(ValidationMessages.PhoneLength);
    }
}
