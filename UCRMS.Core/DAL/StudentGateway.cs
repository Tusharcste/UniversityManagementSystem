using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class StudentGateway:BaseGateway
    {
      

        public int SaveAllStudent(Student student)
        {
            string query = "INSERT INTO Students(Name,RegistrationNumber,Email,ContactNo,Date,Address,DepartmentId) VALUES(@name,@registrationNumber,@email,@contactNo,@date,@address,@departmentId)";
            SqlCommand.CommandText = query;
            SqlCommand.Parameters.Clear();
            SqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
            SqlCommand.Parameters["@name"].Value = student.Name; 
            SqlCommand.Parameters.Add("@registrationNumber", SqlDbType.NVarChar);
            SqlCommand.Parameters["@registrationNumber"].Value = student.RegistrationNumber;

            SqlCommand.Parameters.Add("@email", SqlDbType.NVarChar);
            SqlCommand.Parameters["@email"].Value = student.Email;
            SqlCommand.Parameters.Add("@contactNo", SqlDbType.NVarChar);
            SqlCommand.Parameters["@contactNo"].Value = student.ContactNo;

            SqlCommand.Parameters.Add("@date", SqlDbType.Date);
            SqlCommand.Parameters["@date"].Value = student.Date;
            SqlCommand.Parameters.Add("@address", SqlDbType.NVarChar);
            SqlCommand.Parameters["@address"].Value = student.Address;

            SqlCommand.Parameters.Add("@departmentId", SqlDbType.Int);
            SqlCommand.Parameters["@departmentId"].Value = student.DepartmentId;

            SqlConnection.Open();
            int rowaffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowaffected;
        }


        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM VW_StudentsDepartments";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = new Student
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    RegistrationNumber = reader["RegistrationNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    ContactNo = reader["ContactNo"].ToString(),
                    Date = DateTime.Parse(reader["Date"].ToString()),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    DepartmentCode=reader["Code"].ToString(),
                    DepartmentName=reader["DeptName"].ToString(),
                };
                students.Add(student);
            
        }
            reader.Close();
            SqlConnection.Close();
            return students;
        }

       
    }
    }
