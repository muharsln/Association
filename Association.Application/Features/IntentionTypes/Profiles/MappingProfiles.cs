using AutoMapper;
using Association.Core.Entities;
using Association.Application.Features.IntentionTypes.Commands.Create;
using Association.Application.Features.IntentionTypes.Queries.GetList;
using Association.Application.Features.IntentionTypes.Commands.Delete;
using Association.Application.Features.IntentionTypes.Commands.Update;
using Association.Application.Features.IntentionTypes.Queries.GetById;

namespace Association.Application.Features.IntentionTypes.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IntentionType, CreateIntentionTypeCommand>().ReverseMap();
        CreateMap<IntentionType, CreatedIntentionTypeResponse>().ReverseMap();

        CreateMap<IntentionType, DeleteIntentionTypeCommand>().ReverseMap();
        CreateMap<IntentionType, DeletedIntentionTypeResponse>().ReverseMap();

        CreateMap<IntentionType, UpdateIntentionTypeCommand>().ReverseMap();
        CreateMap<IntentionType, UpdatedIntentionTypeResponse>().ReverseMap();

        CreateMap<IntentionType, GetListIntentionTypeDto>().ReverseMap();

        CreateMap<IntentionType, GetByIdIntentionTypeDto>().ReverseMap();
        CreateMap<IntentionType, GetByIdIntentionTypeQuery>().ReverseMap();
    }
}
