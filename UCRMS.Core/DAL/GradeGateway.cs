using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class GradeGateway:BaseGateway
    {
        public List<Grade> GetAllGrades()
        {
            string query = "SELECT * FROM Grades";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            while (reader.Read())
            {
                Grade grade = new Grade
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };

                grades.Add(grade);
            }
            reader.Close();
            SqlConnection.Close();
            return grades;
        }
    }
}