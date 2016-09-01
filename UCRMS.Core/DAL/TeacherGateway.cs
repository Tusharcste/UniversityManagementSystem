using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class TeacherGateway:BaseGateway
    {
        public int SaveAllTeachers(Teacher teacher)
        {
            string query = "INSERT INTO Teachers(Name,Address,Email,ContactNo,DepartmentId,DesignationId,CreditToBeTaken,RemainingCredit) VALUES(@name,@address,@email,@contactNo,@departmentId,@designationId,@creditToBeTaken,@remainingCredit)";
            SqlCommand.CommandText = query;
            SqlCommand.Parameters.Clear();
            
            SqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
            SqlCommand.Parameters["@name"].Value = teacher.Name;
            SqlCommand.Parameters.Add("@address", SqlDbType.NVarChar);
            SqlCommand.Parameters["@address"].Value = teacher.Address;

            SqlCommand.Parameters.Add("@email", SqlDbType.NVarChar);
            SqlCommand.Parameters["@email"].Value = teacher.Email;
            SqlCommand.Parameters.Add("@contactNo", SqlDbType.NVarChar);
            SqlCommand.Parameters["@contactNo"].Value = teacher.ContactNo;

            SqlCommand.Parameters.Add("@designationId", SqlDbType.Int);
            SqlCommand.Parameters["@designationId"].Value = teacher.DesignationId;
            SqlCommand.Parameters.Add("@departmentId", SqlDbType.Int);
            SqlCommand.Parameters["@departmentId"].Value = teacher.DepartmentId;
            

            SqlCommand.Parameters.Add("@creditToBeTaken", SqlDbType.Decimal);
            SqlCommand.Parameters["@creditToBeTaken"].Value =teacher.CreditToBeTaken;
            SqlCommand.Parameters.Add("@remainingCredit", SqlDbType.Decimal);
            SqlCommand.Parameters["@remainingCredit"].Value = teacher.CreditToBeTaken;

            SqlConnection.Open();
            int rowaffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowaffected;
        }

        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM Teachers";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher
                {
                    Id= Convert.ToInt32(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    ContactNo = reader["ContactNo"].ToString(),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    CreditToBeTaken = decimal.Parse(reader["CreditToBeTaken"].ToString()),
                    RemainingCredit = decimal.Parse(reader["RemainingCredit"].ToString())
                };
                teachers.Add(teacher);

            }
            reader.Close();
            SqlConnection.Close();
            return teachers;
        }

        public int AssignCourse(Teacher teacher, Course course)
        {
            if (UpdateTeacher(teacher) == 1 && UpdateCourseStatus(teacher, course) == 1) return 2;
            else return 0;
        }



        private int UpdateTeacher(Teacher teacher)
        {
            string query = "UPDATE Teachers SET RemainingCredit=" + teacher.RemainingCredit + "" + " WHERE Id=" + teacher.Id;
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            int rowAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowAffected;
        }

        private int  UpdateCourseStatus(Teacher teacher, Course course)
        {
            string query = "UPDATE Courses SET TeacherId=" + teacher.Id + "" + "Where Id=" + course.Id;
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            int rowAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowAffected;
        }
    }
}