using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class DesignationGateway:BaseGateway
    {
        public List<Designation> GetAllDesignations()
        {
            string query = "SELECT * FROM Designations";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (reader.Read())
            {
                Designation designation = new Designation
                {
                     Id = Convert.ToInt32(reader["Id"].ToString()),
                     Name = reader["Name"].ToString()
                };
                designations.Add(designation);
                
            }
            reader.Close();
            SqlConnection.Close();
            return designations;
        }
    }
}