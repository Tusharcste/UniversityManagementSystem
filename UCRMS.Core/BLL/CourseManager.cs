using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();
        public bool SaveCourses(Course course)
        {
            return courseGateway.SaveCourses(course) > 0;
        }

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }

        public List<Course> GetAllCourseStatistics()
        {
            return courseGateway.GetCourseStatistics();
        }

        public bool UnassignCourses()
        {
            return courseGateway.UassignCourse();
        }
    }
}