using FluentValidation;

namespace Association.Application.Features.Donors.Commands.Update;
public class UpdateDonorCommandValidator : AbstractValidator<UpdateDonorCommand>
{
    public UpdateDonorCommandValidator()
    {
        RuleFor(d => d.Id).NotEmpty();
    }
}
