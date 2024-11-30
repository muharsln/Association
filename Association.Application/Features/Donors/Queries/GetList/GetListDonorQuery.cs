using MediatR;

namespace Association.Application.Features.Donors.Queries.GetList;
public record GetListDonorQuery : IRequest<ICollection<GetListDonorDto>> { }
