using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class GradeManager
    {
        GradeGateway gradeGateway=new GradeGateway();
        public List<Grade> GetAllGrades()
        {
            return gradeGateway.GetAllGrades();
        }
    }
}