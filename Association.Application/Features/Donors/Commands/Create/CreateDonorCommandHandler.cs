using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Commands.Create;
public class CreateDonorCommandHandler(IMapper mapper, IDonorService donorService, DonorBusinessRules donorBusinessRules) : IRequestHandler<CreateDonorCommand, CreatedDonorResponse>
{
    public async Task<CreatedDonorResponse> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = mapper.Map<Donor>(request);

        await donorBusinessRules.CheckIfEmailExistsAsync(donor);

        Donor createdDonor = await donorService.AddAsync(donor);

        CreatedDonorResponse response = mapper.Map<CreatedDonorResponse>(createdDonor);

        return response;
    }
}
