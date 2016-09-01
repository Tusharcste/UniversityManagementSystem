using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseResultManagementSystem.Models
{
    public class StudentCourses
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public DateTime EnrollDate { get; set; }
        public string GradeId { get; set; }
        public string GradeName { get; set; }

    }
}