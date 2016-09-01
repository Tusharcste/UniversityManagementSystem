using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.BLL;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        RoomManager roomManager=new RoomManager();
        CourseManager courseManager=new CourseManager();
        ClassroomManager classroomManager=new ClassroomManager();
        //
        // GET: /Classroom/
        public ActionResult AllocateClassroom()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            List<Room> rooms = roomManager.GetAllRooms();
            ViewBag.roomsList = rooms;
            ViewBag.daysList = GetDaysList();
            List<Course> courses = courseManager.GetAllCourses();
            ViewBag.coursesList = courses;
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClassroom(Classroom classroom)
        {

            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            List<Room> rooms = roomManager.GetAllRooms();
            ViewBag.roomsList = rooms;
            ViewBag.daysList = GetDaysList();
            List<Course> courses = courseManager.GetAllCourses();
            ViewBag.coursesList = courses;
            
            
            
            
            List<Classroom> allocateClassroomList = classroomManager.GetAllAllocationInfo().Where(a => a.Day == classroom.Day ).ToList();
            if (allocateClassroomList.Count > 0)
            {
                TimeSpan requestedForm = classroom.ClassStartFrom.TimeOfDay;
                TimeSpan requestedTo = classroom.ClassEndAt.TimeOfDay;
                int count = 0;
                foreach (var allocatedClassroom in allocateClassroomList)
                {
                    count++;
                    TimeSpan allocatedForm = allocatedClassroom.ClassStartFrom.TimeOfDay;
                    TimeSpan allocatedTo = allocatedClassroom.ClassEndAt.TimeOfDay;
                    if (allocatedClassroom.CourseId == classroom.CourseId)
                    {
                        if (TimeSpan.Compare(allocatedTo, requestedForm) < 0 || TimeSpan.Compare(allocatedForm, requestedForm) > 0 && TimeSpan.Compare(allocatedForm, requestedTo) > 0)
                        {
                            ViewBag.Message = classroomManager.AllocateClassroom(classroom) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
                            break;
                        }
                        ViewBag.Message = "Course Already Allocated For This Time";
                        break;
                    }
                    else if (allocatedClassroom.RoomId == classroom.RoomId)
                    {
                        if (TimeSpan.Compare(allocatedTo, requestedForm) < 0 || TimeSpan.Compare(allocatedForm, requestedForm) > 0 && TimeSpan.Compare(allocatedForm, requestedTo) > 0)
                        {
                            ViewBag.Message = classroomManager.AllocateClassroom(classroom) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
                            break;
                        }
                        ViewBag.FailMessage = "Room Already Allocated For This Time";
                        break;
                    }
                    else if (allocateClassroomList.Count == count)
                    {
                        ViewBag.Message = classroomManager.AllocateClassroom(classroom)? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
                        break;
                    }
                }
            }
            else
            {
                ViewBag.Message = classroomManager.AllocateClassroom(classroom) ? "Classroom For This Course Allocated Successfully" : "Classroom Allocation Failed";
            }
            return View();
        }

        public List<Day> GetDaysList()
        {
            List<Day> daysList = new List<Day>
            {
                new Day {Id = 1, Name = "Sunday"}, new Day {Id = 2, Name = "Monday"}, new Day {Id = 3, Name = "Tuesday"},
                new Day {Id = 4, Name = "Wednesday"}, new Day {Id = 5, Name = "Thursday"}, new Day {Id = 6, Name = "Friday"},
                new Day {Id = 7, Name = "Saturday"}
            };
            return daysList;
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            List<Course> coursesList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ScheduleInformation()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            return View();
        }

        public JsonResult GetRoomAllocationInfoList(int departmentId)
        {
            var scheduleInfoList = classroomManager.GetScheduleInformation(departmentId);
            return Json(scheduleInfoList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Unallocate()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Unallocate")]
        public ActionResult UnallocateRooms()
        {
            if (classroomManager.UnallocateRooms())
            {
                ViewBag.SuccessMessage = "All rooms unallocated Successfully!";
            }
            else
            {
                ViewBag.SuccessMessage = "All rooms are already unallocated!";
            }
            return View();
        }

    }
}