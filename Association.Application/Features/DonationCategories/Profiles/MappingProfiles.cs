using AutoMapper;
using Association.Core.Entities;
using Association.Application.Features.DonationCategories.Commands.Create;
using Association.Application.Features.DonationCategories.Commands.Delete;
using Association.Application.Features.DonationCategories.Commands.Update;
using Association.Application.Features.DonationCategories.Queries.GetList;
using Association.Application.Features.DonationCategories.Queries.GetById;

namespace Association.Application.Features.DonationCategories.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DonationCategory, CreateDonationCategoryCommand>().ReverseMap();
        CreateMap<DonationCategory, CreatedDonationCategoryResponse>().ReverseMap();

        CreateMap<DonationCategory, DeleteDonationCategoryCommand>().ReverseMap();
        CreateMap<DonationCategory, DeletedDonationCategoryResponse>().ReverseMap();

        CreateMap<DonationCategory, UpdateDonationCategoryCommand>().ReverseMap();
        CreateMap<DonationCategory, UpdatedDonationCategoryResponse>().ReverseMap();

        CreateMap<DonationCategory, GetListDonationCategoryDto>().ReverseMap();

        CreateMap<DonationCategory, GetByIdDonationCategoryDto>().ReverseMap();
        CreateMap<DonationCategory, GetByIdDonationCategoryQuery>().ReverseMap();
    }
}
