using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseResultManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Remote("IsStudentEmailExists", "StudentProportion", ErrorMessage = "Email already exists! Please try another.")]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        [Remote("IsStudentContactExists", "StudentProportion", ErrorMessage = "Contact No. already exists! Please try another.")]
        public string ContactNo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Address { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public Department Department { get; set; }
        public List<Course> Courses { get; set; }
        public Course CoursesCourse { get; set; }
        public Grade Grades { get; set; }
    }
}