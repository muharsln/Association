using FluentValidation;

namespace Association.Application.Features.Donors.Commands.Delete;

public class DeleteDonorCommandValidator : AbstractValidator<DeleteDonorCommand>
{
    public DeleteDonorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}