using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.DAL
{
    public class ClassroomGateway:BaseGateway
    {
        public bool IsThisClassRoomsOverlapped(Classroom classroom)
        {
            string query = "SELECT * FROM Classrooms WHERE (('" + classroom.ClassStartFrom + "' BETWEEN ClassStartFrom AND ClassEndAt) OR ('" + classroom.ClassEndAt + "' BETWEEN ClassStartFrom AND ClassEndAt)) AND RoomId ='" + classroom.RoomId + "' AND Day ='" + classroom.Day + "'";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Classroom> roomsAllocateClassrooms = new List<Classroom>();
            if (reader.HasRows)
            {
                SqlConnection.Close();
                return true;
            }

            SqlConnection.Close();
            return false;
        }
        
        public List<Classroom> GetAllAllocationInfo()
        {
            string query = "SELECT * FROM Classrooms";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<Classroom> classrooms = new List<Classroom>();
            while (reader.Read())
            {
                Classroom classroom = new Classroom
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                    RoomId = Convert.ToInt32(reader["RoomId"].ToString()),
                    Day = reader["Day"].ToString(),
                    ClassStartFrom = DateTime.Parse(reader["ClassStartFrom"].ToString()),
                    ClassEndAt = DateTime.Parse(reader["ClassEndAt"].ToString()),
                };
                classrooms.Add(classroom);

            }
            reader.Close();
            SqlConnection.Close();
            return classrooms;
           
        }

        public int AllocateClassroom(Classroom classroom)
        {
            string query = "INSERT INTO Classrooms(DepartmentId,CourseId,RoomId,Day,ClassStartFrom,ClassEndAt) VALUES(@departmentId,@courseId,@roomId,@day,@classStartFrom,@classEndAt)";
            SqlCommand.CommandText = query;
            SqlCommand.Parameters.Clear();

            SqlCommand.Parameters.Add("@departmentId", SqlDbType.Int);
            SqlCommand.Parameters["@departmentId"].Value =classroom.DepartmentId;
            SqlCommand.Parameters.Add("@courseId", SqlDbType.Int);
            SqlCommand.Parameters["@courseId"].Value = classroom.CourseId;

            SqlCommand.Parameters.Add("@roomId", SqlDbType.Int);
            SqlCommand.Parameters["@roomId"].Value = classroom.RoomId;
            SqlCommand.Parameters.Add("@day", SqlDbType.NVarChar);
            SqlCommand.Parameters["@day"].Value = classroom.Day;

            SqlCommand.Parameters.Add("@classStartFrom", SqlDbType.Time);
            SqlCommand.Parameters["@classStartFrom"].Value = classroom.ClassStartFrom.TimeOfDay;
            SqlCommand.Parameters.Add("@classEndAt", SqlDbType.Time);
            SqlCommand.Parameters["@classEndAt"].Value = classroom.ClassEndAt.TimeOfDay;


            SqlConnection.Open();
            int rowaffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowaffected;
        }

        public List<ScheduleInformation> GetScheduleInformation(int departmentId)
        {
                   
            string query = "SELECT * FROM VW_ScheduleInformation WHERE DepartmentId='" + departmentId + "'";
            SqlCommand.CommandText = query;
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            List<ScheduleInformation> roomAllocationInfoList = new List<ScheduleInformation>();
            while (reader.Read())
            {
                ScheduleInformation roomAllocationInfo = new ScheduleInformation()
                {
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Day = reader["Day"].ToString() != "" ? reader["Day"].ToString().Substring(0, 3) : reader["Day"].ToString(),
                    RoomName = reader["RoomNo"].ToString(),
                    ClassStartFrom =reader["ClassStartFrom"].ToString(),
                    ClassEndAt = reader["ClassEndAt"].ToString(),
                };
                roomAllocationInfoList.Add(roomAllocationInfo);
            }
            reader.Close();
            SqlConnection.Close();
            return roomAllocationInfoList;
        }

        public bool UnallocateRooms()
        {
            string query = "DELETE FROM Classrooms";
            SqlCommand.CommandText = query;
            SqlConnection.Open();            
            int rowsAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            bool isUnallocated = rowsAffected > 0;
            return isUnallocated;
        }
    }
}