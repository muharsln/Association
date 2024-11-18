using MediatR;

namespace Association.Application.Features.Donors.Queries.GetById;

public class GetByIdDonorQuery(Guid id) : IRequest<GetByIdDonorDto>
{
    public Guid Id { get; set; } = id;
}
