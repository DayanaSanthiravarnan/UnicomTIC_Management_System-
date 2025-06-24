using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ITimetableService
    {
        int AddTimetable(TimetableDTO dto);
        void UpdateTimetable(TimetableDTO dto);
        void DeleteTimetable(int timetableId);
        TimeTable GetTimetableById(int timetableId); // You can change this to TimetableDTO if needed
        List<TimeTable> GetAllTimetables();          // Same here: use List<TimetableDTO> if you want
        List<TimeTable> GetTimetablesByCourseId(int courseId);
        List<TimeTable> GetTimetablesByMainGroupId(int mainGroupId);
        bool IsSlotOccupied(TimetableDTO dto, int? ignoreTimetableId = null);
        List<TimetableDTO> GetTimetableViewByGroup(int mainGroupId, int? subGroupId);


    }
}

