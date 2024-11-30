using AutoMapper;
using Association.Core.Entities;
using Association.Application.Features.DonationShares.Commands.Create;
using Association.Application.Features.DonationShares.Queries.GetList;
using Association.Application.Features.DonationShares.Commands.Delete;
using Association.Application.Features.DonationShares.Commands.Update;
using Association.Application.Features.DonationShares.Queries.GetById;

namespace Association.Application.Features.DonationShares.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DonationShare, CreateDonationShareCommand>().ReverseMap();
        CreateMap<DonationShare, CreatedDonationShareResponse>().ReverseMap();

        CreateMap<DonationShare, UpdateDonationShareCommand>().ReverseMap();
        CreateMap<DonationShare, UpdatedDonationShareResponse>().ReverseMap();

        CreateMap<DonationShare, DeleteDonationShareCommand>().ReverseMap();
        CreateMap<DonationShare, DeletedDonationShareResponse>().ReverseMap();

        CreateMap<DonationShare, GetListDonationShareDto>().ReverseMap();

        CreateMap<DonationShare, GetByIdDonationShareDto>().ReverseMap();
        CreateMap<DonationShare, GetByIdDonationShareQuery>().ReverseMap();
    }
}
