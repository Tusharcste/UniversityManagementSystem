using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseResultManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please provide Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be two to seven characters!")]
        [Remote("IsDepartmentCodeExists", "Department",
            ErrorMessage = "Department Code already exists. Please try another!")]
        public string Code { get; set; }
        [Required(ErrorMessage="Please provide Department Name")]
        [StringLength(50)]
        [Remote("IsDepartmentNameExists", "Department",
            ErrorMessage = "Department Name already exists. Please try another!")]
        public string Name { get; set; }
    }
}