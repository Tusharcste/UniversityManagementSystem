using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway=new TeacherGateway();
        public bool SaveTeachers(Teacher teacher)
        {
            return teacherGateway.SaveAllTeachers(teacher) > 0;
        }

        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeachers();
        }

        public bool AssignCourse(Course coursesList, Teacher teachersList)
        {
            return teacherGateway.AssignCourse(teachersList, coursesList) > 1;
        }
    }
}