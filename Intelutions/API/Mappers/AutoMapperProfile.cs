using API.DTOs;
using AutoMapper;
using Domain.Entities;

namespace API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Permission, PermissionDTO>()
                .ForMember(dest =>
                    dest.PermissionType,
                    opt => opt.MapFrom(src => src.PermissionType.Description))
                .ReverseMap();
            
            CreateMap<PermissionDTO, Permission>();
            CreateMap<PermissionDTO, ResponsePermissionDTO>();

            CreateMap<PermissionType, SelectedValuesDTO>()
                .ForMember(dest =>
                    dest.Value,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Text,
                    opt => opt.MapFrom(src => src.Description))
                .ReverseMap(); ;
        }
    }
}
