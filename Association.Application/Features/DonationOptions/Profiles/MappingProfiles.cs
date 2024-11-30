using AutoMapper;
using Association.Core.Entities;
using Association.Application.Features.DonationOptions.Commands.Create;
using Association.Application.Features.DonationOptions.Commands.Delete;
using Association.Application.Features.DonationOptions.Commands.Update;
using Association.Application.Features.DonationOptions.Queries.GetList;
using Association.Application.Features.DonationOptions.Queries.GetById;

namespace Association.Application.Features.DonationOptions.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DonationOption, CreateDonationOptionCommand>().ReverseMap();
        CreateMap<DonationOption, CreatedDonationOptionResponse>().ReverseMap();

        CreateMap<DonationOption, DeleteDonationOptionCommand>().ReverseMap();
        CreateMap<DonationOption, DeletedDonationOptionResponse>().ReverseMap();

        CreateMap<DonationOption, UpdateDonationOptionCommand>().ReverseMap();
        CreateMap<DonationOption, UpdatedDonationOptionResponse>().ReverseMap();

        CreateMap<DonationOption, GetListDonationOptionDto>().ReverseMap();

        CreateMap<DonationOption, GetByIdDonationOptionDto>().ReverseMap();
        CreateMap<DonationOption, GetByIdDonationOptionQuery>().ReverseMap();
    }
}
