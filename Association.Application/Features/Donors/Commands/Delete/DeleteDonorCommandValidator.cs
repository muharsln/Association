using FluentValidation;

namespace Association.Application.Features.Donors.Commands.Delete;
public class DeleteDonorCommandValidator : AbstractValidator<DeleteDonorCommand>
{
    public DeleteDonorCommandValidator() =>
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Geçerli bir id değeri gönderiniz");
}
