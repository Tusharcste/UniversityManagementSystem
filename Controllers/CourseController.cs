using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.BLL;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager teacherManager=new TeacherManager();
        SemesterManager semesterManager=new SemesterManager();
        CourseManager courseManager = new CourseManager();
        public ActionResult Save()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            List<Semester> semesters = semesterManager.GetAllSemesters();
            ViewBag.departmentsList = departments;
            ViewBag.semestersList = semesters;
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = false;
                isSaved = courseManager.SaveCourses(course);
                List<Department> departments = departmentManager.GetAllDepartments();
                List<Semester> semesters = semesterManager.GetAllSemesters();
                ViewBag.departmentsList = departments;
                ViewBag.semestersList = semesters;
                ViewBag.Message = isSaved ? "Courses Saved Successfully" : "Courses is not saved";
            }
            else
            {
                ViewBag.Message = "Please Fill Up this Form with proper data";
            }
           
            
            return View();
        }
        public ActionResult AssignToTeacher()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            return View();
         }
        [HttpPost]
        public ActionResult AssignToTeacher(int departmentId, int teacherId, int courseId)
        {

            Teacher teacher = teacherManager.GetAllTeachers().FirstOrDefault(a => a.Id == teacherId);
            Course course = courseManager.GetAllCourses().FirstOrDefault(a => a.Id == courseId);
            if (teacher != null && course != null)
            {
                teacher.RemainingCredit = teacher.RemainingCredit - course.Credit;
                if (ModelState.IsValid)
                {
                    if (course.TeacherId == string.Empty)
                    {
                        ViewBag.Message = teacherManager.AssignCourse(course, teacher)
                            ? "Course Assigned Successfully"
                            : "Course Assign Failed";
                    }
                    else
                    {
                        ViewBag.FailMessage = "The Course is already assigned by a teacher";
                    }
                }
                else
                {
                    ViewBag.FailMessage = "Please Fill up With Proper Data!!";
                }
               

            }
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            return View();
        }
        public JsonResult GetTeachersByDepartmentId(int? departmentId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers();
            List<Teacher> teachersList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teachersList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDepartmentId(int? departmentId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            List<Course> coursesList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeachersDetails(int? teacherId)
        {
            Teacher teacher = teacherManager.GetAllTeachers().FirstOrDefault(a => a.Id == teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseDetails(int? courseId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            List<Course> coursesList = courses.Where(a => a.Id == courseId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Statistics()
        {
            var departmentList = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departmentList;
            return View();
        }
        public JsonResult GetCourseStatistics(int? departmentId)
        {
            var courses = courseManager.GetAllCourseStatistics();
            var courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            List<CourseStatistics> coursesList = new List<CourseStatistics>();
            foreach (var item in courseList)
            {
                CourseStatistics coursesStatistics = new CourseStatistics
                {
                    Code = item.Code,
                    Name = item.Name,
                    SemesterName = item.SemesterName,
                    TeacherName = item.TeacherName, 
                };
                coursesList.Add(coursesStatistics);
            }
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Unassign()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Unassign")]
        public ActionResult UnassignCourses()
        {
            if (courseManager.UnassignCourses())
            {
                ViewBag.SuccessMessage = "All Courses Unassigned Successfully!";
            }
            else
            {
                ViewBag.SuccessMessage = "All rooms are already unassigned!";
            }
            return View();
        }

        public JsonResult IsCourseCodeExists(string code)
        {
            List<Course> courses = courseManager.GetAllCourses().Where(a => a.Code == code).ToList();
            if (courses.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCourseNameExists(string name)
        {
            List<Course> courses = courseManager.GetAllCourses().Where(a => a.Name == name).ToList();
            if (courses.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}