using MediatR;

namespace Association.Application.Features.Donors.Queries.GetList;

public class GetListDonorQuery : IRequest<ICollection<GetListDonorDto>> { }