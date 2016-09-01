using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway=new DesignationGateway();
        public List<Designation> GetAllDesignations()
        {
            return designationGateway.GetAllDesignations();
        }
    }
}