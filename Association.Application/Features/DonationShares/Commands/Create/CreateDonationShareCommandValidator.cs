using FluentValidation;

namespace Association.Application.Features.DonationShares.Commands.Create;
public class CreateDonationShareCommandValidator : AbstractValidator<CreateDonationShareCommand>
{
    public CreateDonationShareCommandValidator()
    {
        RuleFor(d => d.DonationFormId)
            .NotEmpty().WithMessage("Bağış formu id değeri boş olamaz")
            .NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");

        RuleFor(d => d.DonationOptionId)
            .NotEmpty().WithMessage("Bağış seçeneği id değeri boş olamaz")
            .NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");

        RuleFor(d => d.IntentionTypeId)
            .NotEmpty().WithMessage("Bağış niyet tipi id değeri boş olamaz")
            .NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");

        RuleFor(d => d.FirstName).NotEmpty().WithMessage("İsim değeri boş gönderilemez");
        RuleFor(d => d.LastName).NotEmpty().WithMessage("Soyisim değeri boş gönderilemez");
        RuleFor(d => d.Phone)
            .NotEmpty().WithMessage("Telefon değeri boş gönderilemez")
            .Length(10,10).WithMessage("10 karakter olarak giriniz");
    }
}
