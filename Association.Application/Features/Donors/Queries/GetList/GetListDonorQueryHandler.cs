using Association.Application.Services.Donors;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.Donors.Queries.GetList;

public class GetListDonorQueryHandler : IRequestHandler<GetListDonorQuery, ICollection<GetListDonorDto>>
{
    private readonly IDonorService _donorService;
    private readonly IMapper _mapper;

    public GetListDonorQueryHandler(IDonorService donorService, IMapper mapper)
    {
        _donorService = donorService;
        _mapper = mapper;
    }

    public async Task<ICollection<GetListDonorDto>> Handle(GetListDonorQuery request, CancellationToken cancellationToken)
    {
        var donors = await _donorService.GetListAsync();
        return _mapper.Map<ICollection<GetListDonorDto>>(donors);
    }
}