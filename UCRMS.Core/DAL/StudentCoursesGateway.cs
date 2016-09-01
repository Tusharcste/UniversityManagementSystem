using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class StudentCoursesGateway :BaseGateway
    {

        public int SaveAllStudentCourses(StudentCourses studentCourses)
        {
            string query = "INSERT INTO StudentCourses(Student_Id,Course_Id,EnrollDate) VALUES(@studentId,@courseId,@enrollDate)";
            SqlCommand.CommandText = query;
            SqlCommand.Parameters.Clear();

            SqlCommand.Parameters.Add("@studentId", SqlDbType.Int);
            SqlCommand.Parameters["@studentId"].Value = studentCourses.StudentId;
            SqlCommand.Parameters.Add("@courseId", SqlDbType.Int);
            SqlCommand.Parameters["@courseId"].Value = studentCourses.CourseId;

            SqlCommand.Parameters.Add("@enrollDate", SqlDbType.Date);
            SqlCommand.Parameters["@enrollDate"].Value = studentCourses.EnrollDate;


            SqlConnection.Open();
            int rowaffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowaffected;
        }
        public List<StudentCourses> GetAllStudentCourse()
        {
            string query = "SELECT * FROM StudentCourses";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<StudentCourses> studentCourseses = new List<StudentCourses>();
            while (reader.Read())
            {
                StudentCourses studentCourse = new StudentCourses
                {
                    StudentId =  Convert.ToInt32(reader["Student_Id"].ToString()),
                    CourseId =  Convert.ToInt32(reader["Course_Id"].ToString()),
                    GradeId = reader["GradeId"].ToString(),
                    
                };
                studentCourseses.Add(studentCourse);
            }
            reader.Close();
            SqlConnection.Close();
            return studentCourseses;
        }



        public int UpdateAllStudentCourse(StudentCourses studentCourses)
        {
            string query = "UPDATE StudentCourses SET GradeId = '" + studentCourses.GradeId + "' WHERE Student_Id = '" + studentCourses.StudentId + "' AND Course_Id = '" + studentCourses.CourseId + "'";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            int rowAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowAffected;
        }
        public List<StudentCourses> GetAllStudentsView()
        {
            string query = "SELECT * FROM VW_StudentCoursesGrade";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<StudentCourses> studentCourseses = new List<StudentCourses>();
            while (reader.Read())
            {
                StudentCourses studentCourse = new StudentCourses
                {
                    StudentId = Convert.ToInt32(reader["Student_Id"].ToString()),
                    CourseId = Convert.ToInt32(reader["Course_Id"].ToString()),
                    CourseCode = reader["Code"].ToString(),
                    CourseName = reader["Name"].ToString(),
                    GradeName = reader["GradeName"].ToString() != string.Empty
                            ? reader["GradeName"].ToString()
                            : "Not Graded Yet",
                    EnrollDate = DateTime.Parse(reader["EnrollDate"].ToString())
                };
                studentCourseses.Add(studentCourse);

            }
            reader.Close();
            SqlConnection.Close();
            return studentCourseses;
        }
    }
}