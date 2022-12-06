using AutoMapper;
using University.DAL.Entities;
using Unversity.BLL.Dtos;

namespace Unversity.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<StudentCreateDto, Student>().ReverseMap();
        }
    }
}
