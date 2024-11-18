using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Commands.Create;

public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, CreatedDonorResponse>
{
    private readonly IMapper _mapper;
    private readonly IDonorService _donorService;
    private readonly DonorBusinessRules _donorBusinessRules;

    public CreateDonorCommandHandler(IMapper mapper, IDonorService donorService, DonorBusinessRules donorBusinessRules)
    {
        _mapper = mapper;
        _donorService = donorService;
        _donorBusinessRules = donorBusinessRules;
    }

    public async Task<CreatedDonorResponse> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        Donor donor = _mapper.Map<Donor>(request);

        await _donorBusinessRules.CheckIfEmailExists(donor);

        Donor createdDonor = await _donorService.AddAsync(donor);

        CreatedDonorResponse response = _mapper.Map<CreatedDonorResponse>(createdDonor);

        return response;
    }
}