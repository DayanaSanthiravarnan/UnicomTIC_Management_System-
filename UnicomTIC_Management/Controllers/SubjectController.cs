using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class SubjectController
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        public void AddSubject(SubjectDTO subjectDTO)
        {
            try
            {
                _service.AddSubject(subjectDTO);
                MessageBox.Show("Subject added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subject: {ex.Message}");
            }
        }

        public void UpdateSubject(SubjectDTO subjectDTO)
        {
            try
            {
                _service.UpdateSubject(subjectDTO);
                MessageBox.Show("Subject updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating subject: {ex.Message}");
            }
        }

        public void DeleteSubject(int subjectId)
        {
            try
            {
                _service.DeleteSubject(subjectId);
                MessageBox.Show("Subject deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting subject: {ex.Message}");
            }
        }

        public SubjectDTO GetSubjectById(int subjectId)
        {
            return _service.GetSubjectById(subjectId);
        }

        public List<SubjectDTO> GetAllSubjects()
        {
            return _service.GetAllSubjects();
        }
    }
}
