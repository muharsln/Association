using Association.Application.Features.DonationForms.Commands.Create;
using Association.Application.Features.DonationForms.Commands.Delete;
using Association.Application.Features.DonationForms.Commands.Update;
using Association.Application.Features.DonationForms.Queries.GetById;
using Association.Application.Features.DonationForms.Queries.GetList;
using Association.Core.Entities;
using AutoMapper;

namespace Association.Application.Features.DonationForms.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DonationForm, CreateDonationFormCommand>().ReverseMap();
        CreateMap<DonationForm, CreatedDonationFormResponse>().ReverseMap();

        CreateMap<DonationForm, UpdateDonationFormCommand>().ReverseMap();
        CreateMap<DonationForm, UpdatedDonationFormResponse>().ReverseMap();

        CreateMap<DonationForm, DeleteDonationFormCommand>().ReverseMap();
        CreateMap<DonationForm, DeletedDonationFormResponse>().ReverseMap();

        CreateMap<DonationForm, GetListDonationFormDto>().ReverseMap();

        CreateMap<DonationForm, GetByIdDonationFormDto>().ReverseMap();
        CreateMap<DonationForm, GetByIdDonationFormQuery>().ReverseMap();
    }
}
