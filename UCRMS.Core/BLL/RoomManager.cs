using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class RoomManager
    {
        RoomGateway roomGateway=new RoomGateway();
        public List<Room> GetAllRooms()
        {
            return roomGateway.GetAllRoomsList();
        }
    }
}