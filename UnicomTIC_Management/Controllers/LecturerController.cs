using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class LecturerController
    {
        private readonly ILecturerService _service;

        public LecturerController(ILecturerService service)
        {
            _service = service;
        }

        public int AddLecturer(LecturerDTO lecturerDTO)
        {
            try
            {
                return _service.AddLecturer(lecturerDTO);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding lecturer: {ex.Message}");
                return -1;
            }
        }

        public void UpdateLecturer(LecturerDTO lecturerDTO)
        {
            try
            {
                _service.UpdateLecturer(lecturerDTO);
                MessageBox.Show("Lecturer updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating lecturer: {ex.Message}");
            }
        }

        public void DeleteLecturer(int lecturerId)
        {
            try
            {
                _service.DeleteLecturer(lecturerId);
                MessageBox.Show("Lecturer deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting lecturer: {ex.Message}");
            }
        }

        public LecturerDTO GetLecturerById(int lecturerId)
        {
            return _service.GetLecturerById(lecturerId);
        }

        public List<LecturerDTO> GetAllLecturers()
        {
            return _service.GetAllLecturers();
        }
    }
}
