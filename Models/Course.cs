using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseResultManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please provide Course Code")]
        [StringLength(100,MinimumLength = 5, ErrorMessage = "Code must at least five  characters long!")]
        [Remote("IsCourseCodeExists", "Course",
            ErrorMessage = "Course Code already exists. Please try another!")]
        public string Code { get; set; }
        [Required(ErrorMessage="please provide Course Name")]
        [Remote("IsCourseNameExists", "Course",
            ErrorMessage = "Course Name already exists. Please try another!")]
        public string Name { get; set; }
        [Required, Range(0.5, 5.0, ErrorMessage = "Credit must be between 0.5 to 5.0")]
        public decimal Credit { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage="Please Select Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Semester")]
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        
    }
}