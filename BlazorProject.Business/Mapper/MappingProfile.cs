using AutoMapper;
using BlazorProject.DataAccess.Data;
using BlazorProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorProject.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
        }
    }
}
