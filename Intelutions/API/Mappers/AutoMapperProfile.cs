using API.DTOs;
using AutoMapper;
using Domain.Entities;

namespace API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Permission, PermissionDTO>();
            CreateMap<PermissionDTO, Permission>();
        }
    }
}
