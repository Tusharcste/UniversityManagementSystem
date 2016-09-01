using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseResultManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter an Email Address of the Teacher")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Remote("IsTeacherEmailExists", "Teacher", ErrorMessage = "Email already exists! Please try another.")]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        [Remote("IsTeacherContactExists", "Teacher", ErrorMessage = "Contact No already exists! Please try another.")]
        public string ContactNo { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "Credit to be taken must be a non-negative value")]
        public decimal CreditToBeTaken { get; set; }
        public decimal RemainingCredit { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int DesignationId { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
    }
}