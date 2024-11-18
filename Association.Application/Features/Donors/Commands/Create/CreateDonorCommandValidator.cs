using FluentValidation;

namespace Association.Application.Features.Donors.Commands.Create;

public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
{
    public CreateDonorCommandValidator()
    {
        RuleFor(d => d.Name).NotEmpty().WithMessage("İsim gereklidir.").MinimumLength(2).WithMessage("En az 2 karakterli olmalıdır.");
        RuleFor(d => d.Surname).NotEmpty().WithMessage("Soyisim gereklidir.").MinimumLength(2).WithMessage("En az 2 karakterli olmalıdır.");
        RuleFor(d => d.Email).EmailAddress().When(d => !string.IsNullOrEmpty(d.Email)).WithMessage("E-posta adresi geçerli değildir.");
        RuleFor(d => d.Phone).NotEmpty().WithMessage("Telefon gereklidir.").Length(10, 10).WithMessage("On karakterli olarak giriş yapınız.");
    }
}
