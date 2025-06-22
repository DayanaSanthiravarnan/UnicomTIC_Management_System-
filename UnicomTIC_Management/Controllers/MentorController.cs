using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class MentorController
    {
        private readonly IMentorService _service;

        public MentorController(IMentorService service)
        {
            _service = service;
        }

        // Adds a new mentor and returns the new mentor ID
        public int AddMentor(MentorDTO mentorDTO)
        {
            try
            {
                return _service.AddMentor(mentorDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding mentor: {ex.Message}");
                return -1;
            }
        }

        public void UpdateMentor(MentorDTO mentorDTO)
        {
            try
            {
                _service.UpdateMentor(mentorDTO);
                MessageBox.Show("Mentor updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating mentor: {ex.Message}");
            }
        }

        public void DeleteMentor(int mentorId)
        {
            try
            {
                _service.DeleteMentor(mentorId);
                MessageBox.Show("Mentor deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting mentor: {ex.Message}");
            }
        }

        public MentorDTO GetMentorById(int mentorId)
        {
            try
            {
                return _service.GetMentorById(mentorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving mentor: {ex.Message}");
                return null;
            }
        }

        public List<MentorDTO> GetAllMentors()
        {
            try
            {
                return _service.GetAllMentors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving mentors: {ex.Message}");
                return new List<MentorDTO>();
            }
        }
    }
}
