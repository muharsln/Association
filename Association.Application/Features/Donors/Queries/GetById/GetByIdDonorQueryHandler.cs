using Association.Application.Features.Donors.Rules;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Queries.GetById;
public class GetByIdDonorQueryHandler(IDonorService donorService, IMapper mapper, DonorBusinessRules donorBusinessRules) : IRequestHandler<GetByIdDonorQuery, GetByIdDonorDto>
{
    public async Task<GetByIdDonorDto> Handle(GetByIdDonorQuery request, CancellationToken cancellationToken)
    {
        var donor = mapper.Map<Donor>(request);

        await donorBusinessRules.CheckIfDonorExistsAsync(donor);

        donor = await donorService.GetAsync(predicate: d => d.Id == request.Id);

        return mapper.Map<GetByIdDonorDto>(donor);
    }
}
