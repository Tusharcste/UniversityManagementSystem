using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseResultManagementSystem.Models
{
    public class ResultView
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int  GradeId { get; set; }
        public string GradeName { get; set; }
    }
}
