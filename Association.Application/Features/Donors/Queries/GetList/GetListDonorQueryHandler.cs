using Association.Application.Services.Donors;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Queries.GetList;
public class GetListDonorQueryHandler(IDonorService donorService, IMapper mapper) : IRequestHandler<GetListDonorQuery, ICollection<GetListDonorDto>>
{
    public async Task<ICollection<GetListDonorDto>> Handle(GetListDonorQuery request, CancellationToken cancellationToken)
    {
        var donors = await donorService.GetListAsync();
        return mapper.Map<ICollection<GetListDonorDto>>(donors);
    }
}
