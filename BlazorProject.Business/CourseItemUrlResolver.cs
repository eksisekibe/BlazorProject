﻿using AutoMapper;
using BlazorProject.DataAccess.Data;
using BlazorProject.Models;

namespace BlazorProject.Common
{
    public class CourseItemUrlResolver : IValueResolver<Course, CourseDto, string>
    {
        public string Resolve(Course source, CourseDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
                return ResultConstant.ImageServerUrl + source.ImageUrl;
            return null;
        }
    }
}
