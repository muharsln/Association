using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Queries.GetById;

public class GetByIdDonorQueryHandler : IRequestHandler<GetByIdDonorQuery, GetByIdDonorDto>
{
    private readonly IDonorService _donorService;
    private readonly IMapper _mapper;
    private readonly DonorBusinessRules _donorBusinessRules;
    public GetByIdDonorQueryHandler(IDonorService donorService, IMapper mapper, DonorBusinessRules donorBusinessRules)
    {
        _donorService = donorService;
        _mapper = mapper;
        _donorBusinessRules = donorBusinessRules;
    }
    public async Task<GetByIdDonorDto> Handle(GetByIdDonorQuery request, CancellationToken cancellationToken)
    {
        Donor donor = await _donorService.GetAsync(predicate: d => d.Id == request.Id);

        await _donorBusinessRules.CheckIfDonorExists(donor);

        GetByIdDonorDto donorDto = _mapper.Map<GetByIdDonorDto>(donor);

        return donorDto;
    }
}
