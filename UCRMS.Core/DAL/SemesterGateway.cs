using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class SemesterGateway:BaseGateway
    {
        public List<Semester> GetAllSemesterList()
        {
            string query = "SELECT * FROM Semesters";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (reader.Read())
            {
                Semester semester = new Semester
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };
               
                semesters.Add(semester);
            }
            reader.Close();
            SqlConnection.Close();
            return semesters;
        }
    }
}