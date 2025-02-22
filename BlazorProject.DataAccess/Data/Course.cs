﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorProject.DataAccess.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price Must be have fill")]
        public decimal CoursePrice { get; set; }
        [Required(ErrorMessage = "Must be selected Is-Active")]
        public bool IsActive { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set;}
        public DateTime UpdatedDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
