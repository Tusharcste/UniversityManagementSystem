using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class StudentCoursesManager
    {
        StudentCoursesGateway studentCoursesGateway=new StudentCoursesGateway();
        public List<StudentCourses> GetAllStudentCourse()
        {
            return studentCoursesGateway.GetAllStudentCourse();
        }

        public bool SaveAllStudentCourse(StudentCourses studentCourses)
        {
            return studentCoursesGateway.SaveAllStudentCourses(studentCourses) > 0;
        }

        public bool UpdateAllStudentCourse(StudentCourses studentCourses)
        {
            return studentCoursesGateway.UpdateAllStudentCourse(studentCourses)>0;
        }
        public List<StudentCourses>  GetAllStudentsView()
        {
            return studentCoursesGateway.GetAllStudentsView();
        }
    }
}