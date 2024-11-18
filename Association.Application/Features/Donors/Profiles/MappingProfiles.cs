using AutoMapper;
using Association.Core.Entities;
using Association.Application.Features.Donors.Commands.Create;
using Association.Application.Features.Donors.Commands.Delete;
using Association.Application.Features.Donors.Queries.GetList;
using Association.Application.Features.Donors.Queries.GetById;
using Association.Application.Features.Donors.Commands.Update;

namespace Association.Application.Features.Donors.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Donor, CreateDonorCommand>().ReverseMap();
        CreateMap<Donor, CreatedDonorResponse>().ReverseMap();

        CreateMap<Donor, DeleteDonorCommand>().ReverseMap();
        CreateMap<Donor, DeletedDonorResponse>().ReverseMap();

        CreateMap<Donor, UpdateDonorCommand>().ReverseMap();
        CreateMap<Donor, UpdatedDonorResponse>().ReverseMap();

        CreateMap<Donor, GetListDonorDto>().ReverseMap();

        CreateMap<Donor, GetByIdDonorDto>().ReverseMap();
    }
}
