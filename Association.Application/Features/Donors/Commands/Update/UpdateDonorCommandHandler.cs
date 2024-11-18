using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Commands.Update;

public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, UpdatedDonorResponse>
{
    public readonly IDonorService _donorService;
    public readonly IMapper _mapper;
    public readonly DonorBusinessRules _donorBusinessRules;

    public UpdateDonorCommandHandler(IDonorService donorService, IMapper mapper, DonorBusinessRules donorBusinessRules)
    {
        _donorService = donorService;
        _mapper = mapper;
        _donorBusinessRules = donorBusinessRules;
    }

    public async Task<UpdatedDonorResponse> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = await _donorService.GetAsync(d => d.Id == request.Id);
        await _donorBusinessRules.CheckIfDonorExists(donor);

        // Mevcut donor nesnesinin özelliklerini request nesnesi ile güncelle
        donor.Name = request.Name ?? donor.Name;
        donor.Surname = request.Surname ?? donor.Surname;
        donor.Email = request.Email ?? donor.Email;
        donor.Phone = request.Phone ?? donor.Phone;
        donor.Location = request.Location ?? donor.Location;
        donor.IsActive = request.IsActive ?? donor.IsActive;

        await _donorService.UpdateAsync(donor);

        UpdatedDonorResponse response = _mapper.Map<UpdatedDonorResponse>(donor);
        return response;
    }
}
