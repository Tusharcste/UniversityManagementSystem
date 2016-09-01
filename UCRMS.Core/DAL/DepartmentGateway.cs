using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class DepartmentGateway:BaseGateway
    {
        public int SaveAllDepartments(Department department)
        {
            string query = "INSERT INTO Departments(Code,Name) VALUES(@code,@name)";
            SqlCommand.CommandText = query;
            SqlCommand.Parameters.Clear();
            SqlCommand.Parameters.Add("@code", SqlDbType.NVarChar);
            SqlCommand.Parameters["@code"].Value = department.Code;
            SqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
            SqlCommand.Parameters["@name"].Value = department.Name;
            SqlConnection.Open();
            int rowaffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowaffected;
        }

        public List<Department> GetAllDepartmentsList()
        {
            string query = "SELECT * FROM Departments";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()
                };
                departments.Add(department);
            }
            reader.Close();
            SqlConnection.Close();
            return departments;
        }
    }

}