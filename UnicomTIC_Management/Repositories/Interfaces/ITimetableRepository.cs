using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface ITimetableRepository
    {
        int AddTimetable(TimeTable timetable);
        void UpdateTimetable(TimeTable timetable);
        void DeleteTimetable(int timetableId);
        TimeTable GetTimetableById(int timetableId);
        List<TimeTable> GetAllTimetables();

        // Optional filtering
        List<TimeTable> GetTimetablesByCourseId(int courseId);
        List<TimeTable> GetTimetablesByMainGroupId(int mainGroupId);

        // Conflict check
        bool IsSlotOccupied(TimetableDTO dto, int? ignoreTimetableId = null);
    }
}
