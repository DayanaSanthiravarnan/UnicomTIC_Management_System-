using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class AttendanceController
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        public void AddAttendance(AttendanceDTO attendanceDTO)
        {
            try
            {
                if (_service.IsAttendanceMarked(attendanceDTO.StudentID, attendanceDTO.Date))
                {
                    MessageBox.Show("Attendance for this student on this date already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _service.AddAttendance(attendanceDTO);
                MessageBox.Show("Attendance recorded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding attendance: {ex.Message}");
            }
        }

        public void UpdateAttendance(AttendanceDTO attendanceDTO)
        {
            try
            {
                _service.UpdateAttendance(attendanceDTO);
                MessageBox.Show("Attendance updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attendance: {ex.Message}");
            }
        }

        public void DeleteAttendance(int attendanceId)
        {
            try
            {
                _service.DeleteAttendance(attendanceId);
                MessageBox.Show("Attendance deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting attendance: {ex.Message}");
            }
        }

        public AttendanceDTO GetAttendanceById(int attendanceId)
        {
            return _service.GetAttendanceById(attendanceId);
        }

        public List<AttendanceDTO> GetAllAttendances()
        {
            return _service.GetAllAttendances();
        }

        public bool IsAttendanceMarked(int studentId, string date)
        {
            return _service.IsAttendanceMarked(studentId, date);
        }
    }
}

