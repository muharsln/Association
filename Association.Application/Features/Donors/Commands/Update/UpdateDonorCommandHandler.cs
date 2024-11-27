using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Commands.Update;
public class UpdateDonorCommandHandler(IDonorService donorService, IMapper mapper, DonorBusinessRules donorBusinessRules) : IRequestHandler<UpdateDonorCommand, UpdatedDonorResponse>
{
    public async Task<UpdatedDonorResponse> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = await donorService.GetAsync(d => d.Id == request.Id);
        await donorBusinessRules.CheckIfDonorExistsAsync(donor);

        donor.Name = request.Name ?? donor.Name;
        donor.Surname = request.Surname ?? donor.Surname;
        donor.Email = request.Email ?? donor.Email;
        donor.Phone = request.Phone ?? donor.Phone;
        donor.Location = request.Location ?? donor.Location;
        donor.IsActive = request.IsActive ?? donor.IsActive;

        await donorService.UpdateAsync(donor);

        UpdatedDonorResponse response = mapper.Map<UpdatedDonorResponse>(donor);
        return response;
    }
}
