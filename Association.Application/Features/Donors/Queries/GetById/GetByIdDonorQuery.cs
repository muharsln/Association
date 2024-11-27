using MediatR;

namespace Association.Application.Features.Donors.Queries.GetById;
public record GetByIdDonorQuery(Guid id) : IRequest<GetByIdDonorDto>
{
    public Guid Id { get; init; }
}
