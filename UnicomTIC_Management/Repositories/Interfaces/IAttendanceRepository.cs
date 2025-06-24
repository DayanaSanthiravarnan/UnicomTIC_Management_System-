using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IAttendanceRepository
    {
        void AddAttendance(Attendance attendance);
        void UpdateAttendance(Attendance attendance);
        void DeleteAttendance(int id);
        Attendance GetAttendanceById(int id);
        List<Attendance> GetAllAttendances();
        bool IsAttendanceMarked(int studentId, string date);
    }
}
