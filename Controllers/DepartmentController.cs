using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.BLL;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();

        public ActionResult Save()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Department department)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = false;

                isSaved = departmentManager.SaveDepartments(department);
                ViewBag.Message = isSaved ? "Department Saved Successfully" : "Department is not saved";
            }
            else
            {
                ViewBag.Message = "Please fill Up with Proper Data";
            }
            
           
            return View();
        }
        public ActionResult DepartmentViewAll()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.DepartmentsList = departments;
            return View();
        }
        public JsonResult IsDepartmentCodeExists(string code)
        {
            List<Department> departments =departmentManager.GetAllDepartments().Where(a => a.Code == code).ToList();
            if (departments.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
        public JsonResult IsDepartmentNameExists(string name)
        {
            List<Department> departments = departmentManager.GetAllDepartments().Where(a => a.Name == name).ToList();
            if (departments.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
       
	}
}