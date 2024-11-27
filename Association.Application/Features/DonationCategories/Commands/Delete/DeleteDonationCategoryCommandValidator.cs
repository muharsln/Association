using FluentValidation;

namespace Association.Application.Features.DonationCategories.Commands.Delete;
public class DeleteDonationCategoryCommandValidator : AbstractValidator<DeleteDonationCategoryCommand>
{
    public DeleteDonationCategoryCommandValidator() => 
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
