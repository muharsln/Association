using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Commands.Delete;
public class DeleteDonorCommandHandler(IMapper mapper, IDonorService donorService, DonorBusinessRules donorBusinessRules) : IRequestHandler<DeleteDonorCommand, DeletedDonorResponse>
{
    public async Task<DeletedDonorResponse> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = mapper.Map<Donor>(request);

        await donorBusinessRules.CheckIfDonorExistsAsync(donor);
        await donorBusinessRules.CheckIfDonorHasDonationFormsAsync(donor);

        Donor deletedDonor = await donorService.DeleteAsync(donor);

        DeletedDonorResponse response = mapper.Map<DeletedDonorResponse>(donor);
        return response;
    }
}
