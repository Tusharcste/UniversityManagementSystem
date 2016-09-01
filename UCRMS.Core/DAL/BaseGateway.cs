using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class BaseGateway
    {
        public BaseGateway()
        {
            ConnectionString = WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand();
            SqlCommand.Connection = SqlConnection;


        }
        public string ConnectionString { get; set; }
        public SqlConnection SqlConnection { get; set; }
        public SqlCommand SqlCommand { get; set; }
    }
}