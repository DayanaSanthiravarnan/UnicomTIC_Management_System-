using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Controllers
{
    internal class TimetableController
    {
        private readonly ITimetableService _service;

        public TimetableController(ITimetableService service)
        {
            _service = service;
        }

        public void AddTimetable(TimetableDTO dto)
        {
            try
            {
                _service.AddTimetable(dto);
                MessageBox.Show("Timetable added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding timetable: " + ex.Message);
            }
        }

        public void UpdateTimetable(TimetableDTO dto)
        {
            try
            {
                _service.UpdateTimetable(dto);
                MessageBox.Show("Timetable updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating timetable: " + ex.Message);
            }
        }

        public void DeleteTimetable(int timetableId)
        {
            try
            {
                _service.DeleteTimetable(timetableId);
                MessageBox.Show("Timetable deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting timetable: " + ex.Message);
            }
        }

        public TimetableDTO GetTimetableById(int timetableId)
        {
            var entity = _service.GetTimetableById(timetableId);
            return TimetableMapper.ToDTO(entity);
        }

        public List<TimetableDTO> GetAllTimetables()
        {
            var entities = _service.GetAllTimetables();
            return TimetableMapper.ToDTOList(entities);
        }

        public List<TimetableDTO> GetTimetablesByCourseId(int courseId)
        {
            var entities = _service.GetTimetablesByCourseId(courseId);
            return TimetableMapper.ToDTOList(entities);
        }

        public List<TimetableDTO> GetTimetablesByMainGroupId(int mainGroupId)
        {
            var entities = _service.GetTimetablesByMainGroupId(mainGroupId);
            return TimetableMapper.ToDTOList(entities);
        }

        public bool IsSlotOccupied(TimetableDTO dto, int? ignoreTimetableId = null)
        {
            return _service.IsSlotOccupied(dto, ignoreTimetableId);
        }
        public List<TimetableDTO> GetTimetableViewByGroup(int mainGroupId, int? subGroupId)
        {
            return _service.GetTimetableViewByGroup(mainGroupId, subGroupId);
        }

    }
}