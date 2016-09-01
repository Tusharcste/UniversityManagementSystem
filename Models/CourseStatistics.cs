using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseResultManagementSystem.Models
{
    public class CourseStatistics
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { set; get; }
        public string Name { get; set; }
        public string  SemesterName { get; set; }
        public string TeacherName { get; set; }
        public string TeacherId { get; set; }
        public int SemesterId { get; set; }

    }
}