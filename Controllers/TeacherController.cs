using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.BLL;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        DesignationManager designationManager=new DesignationManager();
        TeacherManager teacherManager=new TeacherManager();
        public ActionResult Save()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            List<Designation> designatons = designationManager.GetAllDesignations();
            ViewBag.departmentsList = departments;
            ViewBag.designationsList = designatons;
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = false;
                isSaved = teacherManager.SaveTeachers(teacher);
                List<Department> departments = departmentManager.GetAllDepartments();
                List<Designation> designatons = designationManager.GetAllDesignations();
                ViewBag.departmentsList = departments;
                ViewBag.designationsList = designatons;
                ViewBag.Message = isSaved ? "Teachers Saved Successfully" : "Teachers is not saved";  
            }
            else
            {
                ViewBag.Message = "Please Fill Up this Teachers Form with Proper Data";
            }
            return View();
        }


        public JsonResult IsTeacherEmailExists(string email)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers().Where(a => a.Email == email).ToList();
            if (teachers.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsTeacherContactExists(string contactNo)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers().Where(a => a.ContactNo == contactNo).ToList();
            if (teachers.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}