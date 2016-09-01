using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseResultManagementSystem.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int ClassroomId { get; set; }
        public int RoomId { get; set; }
        public string Day { get; set; }
        public DateTime ClassStartFrom { get; set; }
        public DateTime ClassEndAt { get; set; }
    }
}