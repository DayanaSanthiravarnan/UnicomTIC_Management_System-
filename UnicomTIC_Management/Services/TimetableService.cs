using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;

        public TimetableService(ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }

        public int AddTimetable(TimetableDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var timetable = TimetableMapper.ToEntity(dto);
            return _timetableRepository.AddTimetable(timetable);
        }

        public void UpdateTimetable(TimetableDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var timetable = TimetableMapper.ToEntity(dto);
            _timetableRepository.UpdateTimetable(timetable);
        }

        public void DeleteTimetable(int timetableId)
        {
            _timetableRepository.DeleteTimetable(timetableId);
        }

        public TimeTable GetTimetableById(int timetableId)
        {
            return _timetableRepository.GetTimetableById(timetableId);
        }

        public List<TimeTable> GetAllTimetables()
        {
            return _timetableRepository.GetAllTimetables();
        }

        public List<TimeTable> GetTimetablesByCourseId(int courseId)
        {
            return _timetableRepository.GetTimetablesByCourseId(courseId);
        }

        public List<TimeTable> GetTimetablesByMainGroupId(int mainGroupId)
        {
            return _timetableRepository.GetTimetablesByMainGroupId(mainGroupId);
        }

        public bool IsSlotOccupied(TimetableDTO dto, int? ignoreTimetableId = null)
        {
            return _timetableRepository.IsSlotOccupied(dto, ignoreTimetableId);
        }
        public List<TimetableDTO> GetTimetableViewByGroup(int mainGroupId, int? subGroupId)
        {
            return _timetableRepository.GetTimetableByGroup(mainGroupId, subGroupId);
        }
    }
}
