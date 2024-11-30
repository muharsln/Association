using AutoMapper;
using Association.Core.Entities;
using Association.Application.Features.DonationGroups.Commands.Create;
using Association.Application.Features.DonationGroups.Commands.Delete;
using Association.Application.Features.DonationGroups.Commands.Update;
using Association.Application.Features.DonationGroups.Queries.GetList;
using Association.Application.Features.DonationGroups.Queries.GetById;

namespace Association.Application.Features.DonationGroups.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DonationGroup, CreateDonationGroupCommand>().ReverseMap();
        CreateMap<DonationGroup, CreatedDonationGroupResponse>().ReverseMap();

        CreateMap<DonationGroup, DeleteDonationGroupCommand>().ReverseMap();
        CreateMap<DonationGroup, DeletedDonationGroupResponse>().ReverseMap();

        CreateMap<DonationGroup, UpdateDonationGroupCommand>().ReverseMap();
        CreateMap<DonationGroup, UpdatedDonationGroupResponse>().ReverseMap();

        CreateMap<DonationGroup, GetListDonationGroupDto>().ReverseMap();

        CreateMap<DonationGroup, GetByIdDonationGroupDto>().ReverseMap();
        CreateMap<DonationGroup, GetByIdDonationGroupQuery>().ReverseMap();
    }
}
