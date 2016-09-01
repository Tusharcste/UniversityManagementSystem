using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();
        public bool SaveDepartments(Department department)
        {
            return departmentGateway.SaveAllDepartments(department)>0;
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartmentsList();
        }

       
    }
}