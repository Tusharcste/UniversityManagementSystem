using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class StudentMangager
    {
      
        StudentGateway studentGateway=new StudentGateway();
        public List<Student> GetAllStudents()
        {
             return  studentGateway.GetAllStudents();
        }

        public bool SaveAllStudent(Student student)
        {
            return studentGateway.SaveAllStudent(student) > 0;
        }

       
    }
}