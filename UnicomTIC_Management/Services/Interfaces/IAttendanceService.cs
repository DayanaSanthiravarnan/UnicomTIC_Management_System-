using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IAttendanceService
    {
        void AddAttendance(AttendanceDTO dto);
        void UpdateAttendance(AttendanceDTO dto);
        void DeleteAttendance(int id);
        AttendanceDTO GetAttendanceById(int id);
        List<AttendanceDTO> GetAllAttendances();
        bool IsAttendanceMarked(int studentId,  string date);
    }
}
