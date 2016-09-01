using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class RoomGateway :BaseGateway
    {
        public List<Room> GetAllRoomsList()
        {
            string query = "SELECT * FROM Rooms";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                Room room = new Room
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    RoomNo = reader["RoomNo"].ToString()
                };
                rooms.Add(room);

            }
            reader.Close();
            SqlConnection.Close();
            return rooms;
        }
    }
}