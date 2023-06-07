using AutoMapper;
using BlazorProject.Common;
using BlazorProject.DataAccess.Data;
using BlazorProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorProject.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap().ForMember(c => c.ImageUrl, o => o.MapFrom<CourseItemUrlResolver>());
            CreateMap<CourseOrderInfo, CourseOrderInfoDto>().ReverseMap();
        }
    }
}
