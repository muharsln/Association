using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Commands.Delete;

public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, DeletedDonorResponse>
{
    private readonly IMapper _mapper;
    private readonly IDonorService _donorService;
    private readonly DonorBusinessRules _donorBusinessRules;

    public DeleteDonorCommandHandler(IMapper mapper, IDonorService donorService, DonorBusinessRules donorBusinessRules)
    {
        _mapper = mapper;
        _donorService = donorService;
        _donorBusinessRules = donorBusinessRules;
    }

    public async Task<DeletedDonorResponse> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = _mapper.Map<Donor>(request);

        await _donorBusinessRules.CheckIfDonorExists(donor);
        await _donorBusinessRules.CheckIfDonorHasDonationForms(donor);

        Donor deletedDonor = await _donorService.DeleteAsync(donor);

        DeletedDonorResponse response = _mapper.Map<DeletedDonorResponse>(donor);
        return response;
    }
}
