using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseResultManagementSystem.Models;
using UniversityCourseResultManagementSystem.UCRMS.Core.DAL;

namespace UniversityCourseResultManagementSystem.UCRMS.Core.BLL
{
    public class ClassroomManager
    {
        ClassroomGateway classroomGateway=new ClassroomGateway();
        public List<Classroom> GetAllAllocationInfo()
        {
            return classroomGateway.GetAllAllocationInfo();
        }

        public bool AllocateClassroom(Classroom classroom)
        {
            if (classroomGateway.IsThisClassRoomsOverlapped(classroom))
            {
                return false;

            }
            else
            {
                if (classroomGateway.AllocateClassroom(classroom) > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public List<ScheduleInformation> GetScheduleInformation(int departmentId)
        {
            return classroomGateway.GetScheduleInformation(departmentId);
        }

        public bool UnallocateRooms()
        {
            return classroomGateway.UnallocateRooms();
        }
    }
}