using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class CourseGateway:BaseGateway
    {
        public int SaveCourses(Course course)
        {
            string query = "INSERT INTO Courses(Code,Name,Credit,Description,DepartmentId,SemesterId) VALUES(@code,@name,@credit,@description,@departmentId,@semesterId)";
            SqlCommand.CommandText = query;
            SqlCommand.Parameters.Clear();
            SqlCommand.Parameters.Add("@code", SqlDbType.NVarChar);
            SqlCommand.Parameters["@code"].Value = course.Code;
            SqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
            SqlCommand.Parameters["@name"].Value = course.Name;

            SqlCommand.Parameters.Add("@credit", SqlDbType.Float);
            SqlCommand.Parameters["@credit"].Value = course.Credit;
            SqlCommand.Parameters.Add("@description", SqlDbType.NVarChar);
            SqlCommand.Parameters["@description"].Value = course.Description;

            SqlCommand.Parameters.Add("@departmentId", SqlDbType.Int);
            SqlCommand.Parameters["@departmentId"].Value = course.DepartmentId;
            SqlCommand.Parameters.Add("@semesterId", SqlDbType.Int);
            SqlCommand.Parameters["@semesterId"].Value = course.SemesterId;
            SqlConnection.Open();
            int rowaffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowaffected;
        }

        public List<Course> GetAllCourses()
        {
            string query = "SELECT * FROM Courses";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id= Convert.ToInt32(reader["Id"].ToString()),
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Credit = decimal.Parse(reader["Credit"].ToString()),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    SemesterId = Convert.ToInt32(reader["SemesterId"].ToString()),
                    TeacherId = reader["TeacherId"].ToString(),
                    
                };
               courses.Add(course);

            }
            reader.Close();
            SqlConnection.Close();
            return courses;
        }

        public List<Course> GetCourseStatistics()
        {
            string query = "SELECT * FROM VW_CourseStatistics";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    SemesterId = Convert.ToInt32(reader["SemesterId"].ToString()),
                    SemesterName = reader["SemesterName"].ToString(),
                    TeacherId = reader["TeacherId"].ToString(),
                    TeacherName =
                        reader["TeacherName"].ToString() != ""
                            ? reader["TeacherName"].ToString()
                            : "Not Assigned Yet",
                };
                courses.Add(course);
            
        }
            reader.Close();
            SqlConnection.Close();
            return courses;
        }

        public bool UassignCourse()
        {
            string query = "UPDATE Courses SET TeacherId=NULL";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            int rowsAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            bool isUnassigned = rowsAffected > 0;
            return isUnassigned;
        }
    }
}