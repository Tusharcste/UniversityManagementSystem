using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway=new SemesterGateway();
        public List<Semester> GetAllSemesters()
        {
            return semesterGateway.GetAllSemesterList();
        }
    }
}