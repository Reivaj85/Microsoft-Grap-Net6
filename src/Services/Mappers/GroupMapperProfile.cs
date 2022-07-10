using AutoMapper;
using Microsoft.Graph;
using POC_MGrap.Domain.DTO;

namespace POC_MGrap.Services.Mappers; 

internal class GroupMapperProfile : Profile {
    public GroupMapperProfile() {
        CreateMap<Group, GroupDto>()
            .ForMember(dto => dto.Id, e => e.MapFrom(_ => _.Id))
            .ForMember(dto => dto.DisplayName, e => e.MapFrom(_ => _.DisplayName))
            .ForMember(dto => dto.Description, e => e.MapFrom(_ => _.Description))
            .ForMember(dto => dto.Mail, e => e.MapFrom(_ => _.Mail));
    }
}
