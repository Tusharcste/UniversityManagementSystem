using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Ajax.Utilities;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.BLL;

namespace UniversityCourseResultManagementSystem.Controllers
{
    public class StudentProportionController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentMangager studentMangager = new StudentMangager();
        CourseManager courseManager=new CourseManager();
        StudentCoursesManager studentCoursesManager=new StudentCoursesManager();
        GradeManager gradeManager=new GradeManager();

        public ActionResult StudentEntry()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            return View();
        }

        [HttpPost]
        public ActionResult StudentEntry(Student student, int departmentId, string regDate)
        {
            Department department = departmentManager.GetAllDepartments().FirstOrDefault(a => a.Id == departmentId);
            if (department != null) student.DepartmentCode = department.Code;
            List<Student> allStudents = studentMangager.GetAllStudents();
            List<Student> studentList = allStudents.Where(a => a.DepartmentId == departmentId).ToList();

            if (ModelState.IsValid)
            {
                int rollNo = studentList.Count;
                if (rollNo > 0)
                {
                    rollNo++;
                    student.RegistrationNumber = student.DepartmentCode + "-" + student.Date.Year + "-" +
                                                 rollNo.ToString("000");
                    ViewBag.RegiNo = student.RegistrationNumber;
                }
                else
                {
                    student.RegistrationNumber = student.DepartmentCode + "-" + student.Date.Year + "-" +
                                                 1.ToString("000");
                    ViewBag.RegiNo = student.RegistrationNumber;
                }
                ViewBag.Message = studentMangager.SaveAllStudent(student)
                    ? "\nRegistration Successfully Done !!\n\nReg No: " + student.RegistrationNumber + "\nName: " +
                      student.Name + " \n\n" + "\nEmail: " + student.Email + "\nContact No.:" + " \n\n" +
                      student.ContactNo + "\nDate:" + student.Date + " \n\n" + "\nAddress: " + student.Address + " \n\n" +
                      "\nDepartment: " + student.DepartmentCode
                    : "Registration Failed";

            }
            else
            {
                ViewBag.Failmessage = "Please Fill up the form with proper data";
            }
            

            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.departmentsList = departments;
            return View();
        }

        public JsonResult GetRegistrationNo(int departmentId,string regDate)
        {
            var regNo = ViewBag.RegiNo;
            return Json(regNo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EnrollCourse()
        {
            List<Student> students = studentMangager.GetAllStudents();
            ViewBag.studentsList = students;
            return View();
        }
        
        [HttpPost]
        public ActionResult EnrollCourse(StudentCourses studentCourses)
        {

           List<StudentCourses> studentIds = studentCoursesManager.GetAllStudentCourse().Where(a=>a.StudentId==studentCourses.StudentId && a.CourseId==studentCourses.CourseId).ToList();
            if (ModelState.IsValid)
            {
                if (studentIds.Count == 0)
                {

                    ViewBag.Message = studentCoursesManager.SaveAllStudentCourse(studentCourses)
                        ? "Student enrolled into department successfully!"
                        : "Student Enrolled is not Saved Successfully";

                }
                else
                {
                    ViewBag.FailMessage = "Student has already enrolled in this course.";
                }
            }

            List<Student> students = studentMangager.GetAllStudents();
            ViewBag.studentsList = students;
            return View();
        }




        public JsonResult GetStudentInfoByStudentId(int studentId)
        {
            List<Student> students = studentMangager.GetAllStudents();
            List<Student> studentList = students.Where(a => a.Id == studentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCourses();
            List<Course> coursesList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCoursesByStudentId(int studentId)
        {
            List<StudentCourses> courses = studentCoursesManager.GetAllStudentsView();
            List<StudentCourses> coursesList = courses.Where(a => a.StudentId == studentId).ToList();
            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveResult()
        {
            List<Student> students = studentMangager.GetAllStudents();
            ViewBag.studentsList = students;
            List<Grade> grades = gradeManager.GetAllGrades();
            ViewBag.gradesList = grades;
            return View();
        }

        [HttpPost]
        public ActionResult SaveResult(StudentCourses studentCourses)
        {
            
                List<StudentCourses> studentIds = studentCoursesManager.GetAllStudentCourse().Where(a => a.StudentId == studentCourses.StudentId && a.CourseId == studentCourses.CourseId).ToList();

            if (ModelState.IsValid)
            {
                var count = studentIds.Count;
                if (count == 1)
                {
                    foreach (var item in studentIds)
                    {
                        if (item.GradeId == string.Empty)
                        {
                            ViewBag.Message = studentCoursesManager.UpdateAllStudentCourse(studentCourses)
                                ? " Student result saved Successfully"
                                : "Student result is not Saved";
                        }
                        else
                        {
                            ViewBag.FailMessage = "Result has Already asigned to this student";
                        }
                    }
                   
                }
                else
                {
                    ViewBag.FailMessage = "You are not enrolled in the course! Please enrolled first!!";
                }
            }
            else
            {
                ViewBag.FailMessage = "Please Fill Up Data properly!!";
            }
                
           
            List<Student> students = studentMangager.GetAllStudents();
            ViewBag.studentsList = students;
            List<Grade> grades = gradeManager.GetAllGrades();
            ViewBag.gradesList = grades;
            return View();

        }

        public ActionResult ViewResult()
        {
            List<Student> students = studentMangager.GetAllStudents();
            ViewBag.studentsList = students;
            return View();
        }

        public ActionResult GetViewResultStatistics(int studentId)
        {
            var students = studentCoursesManager.GetAllStudentsView();
            var studentsList = students.Where(a => a.StudentId == studentId).ToList();
            List<ResultView> viewResults = new List<ResultView>();
            foreach (var item in studentsList)
            {
                ResultView viewResult = new ResultView
                {
                    CourseCode = item.CourseCode,
                    CourseName = item.CourseName,
                    GradeName = item.GradeName,
                };
                viewResults.Add(viewResult);
            }
            return Json(viewResults, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult ViewResult(int? studentId)
        {
            List<Student> students = studentMangager.GetAllStudents();
            List<Department> departments = departmentManager.GetAllDepartments();
            var getStudentById = students.SingleOrDefault(s => s.Id == studentId);
            if (studentId != null)
            {      
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            document.Open();

            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            document.Add(new Paragraph("UCRMS Result Creator", titleFont));
            document.Add(new Paragraph("Student Results are below", bodyFont));

            document.Add(Chunk.NEWLINE);
            document.Add(new Paragraph("Student Information: ", subTitleFont));
            var studentInfoTable = new PdfPTable(2);
            studentInfoTable.HorizontalAlignment = 0;
            studentInfoTable.SpacingBefore = 10;
            studentInfoTable.SpacingAfter = 10;
            studentInfoTable.DefaultCell.Border = 0;
            studentInfoTable.SetWidths(new int[] { 1, 4 });

            studentInfoTable.AddCell(new Phrase("Student Reg. No.:", boldTableFont));
            studentInfoTable.AddCell(getStudentById.RegistrationNumber);
            studentInfoTable.AddCell(new Phrase("Name :", boldTableFont));
            studentInfoTable.AddCell(getStudentById.Name);
            studentInfoTable.AddCell(new Phrase("Email :", boldTableFont));
            studentInfoTable.AddCell(getStudentById.Email);
            studentInfoTable.AddCell(new Phrase("Department :", boldTableFont));

            studentInfoTable.AddCell(departments.Where(c => c.Id == getStudentById.DepartmentId).Select(x => x.Name).Single());
            document.Add(studentInfoTable);

            document.Add(Chunk.NEWLINE);

            document.Add(new Paragraph("Result Informatiion: ", subTitleFont));

            var resultTable = new PdfPTable(3);
            resultTable.HorizontalAlignment = 1;
            resultTable.SpacingBefore = 10;
            resultTable.SpacingAfter = 10;
            resultTable.TotalWidth = 9f;

            resultTable.AddCell(new Phrase("Course Code", boldTableFont));
            resultTable.AddCell(new Phrase("Name", boldTableFont));
            resultTable.AddCell(new Phrase("Grade", boldTableFont));

            var studentsLt = studentCoursesManager.GetAllStudentsView();
            var studentsList = studentsLt.Where(a => a.StudentId == studentId).ToList();
            List<ResultView> viewResults = new List<ResultView>();
            foreach (var item in studentsList)
            {
                ResultView viewResult = new ResultView
                {
                    CourseCode = item.CourseCode,
                    CourseName = item.CourseName,
                    GradeName = item.GradeName,
                };
                resultTable.AddCell(viewResult.CourseCode);
                resultTable.AddCell(viewResult.CourseName);
                resultTable.AddCell(viewResult.GradeName);
                viewResults.Add(viewResult);
            }

             
                document.Add(resultTable);


                DateTime dateTime = DateTime.Now;

                PdfContentByte cb = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bf, 10);
                cb.BeginText();
                cb.SetTextMatrix(50, 5);
                cb.ShowText(dateTime.ToString());
                cb.EndText();
                document.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition",
                    string.Format("attachment;filename=Receipt-{0}.pdf", getStudentById.RegistrationNumber));
                Response.BinaryWrite(output.ToArray());
                ViewBag.Message = dateTime.ToString();
            }
            else
            {
                ViewBag.Message = "Fill all field properly";
            }
            List<Student> studentsView = studentMangager.GetAllStudents();
            ViewBag.studentsList = studentsView;
            return View();
        }

        public JsonResult IsStudentEmailExists(string email)
        {
            List<Student> students = studentMangager.GetAllStudents().Where(a => a.Email == email).ToList();
            if (students.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsStudentContactExists(string contactNo)
        {
            List<Student> students = studentMangager.GetAllStudents().Where(a => a.ContactNo == contactNo).ToList();
            if (students.Count > 0) { return Json(false, JsonRequestBehavior.AllowGet); }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

       
    }
}