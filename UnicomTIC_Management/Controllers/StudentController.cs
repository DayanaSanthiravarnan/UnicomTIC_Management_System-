using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

      
        public int AddStudent(StudentDTO studentDTO)
        {
            try
            {
                return _service.AddStudent(studentDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}");
                return -1;
            }
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            try
            {
                _service.UpdateStudent(studentDTO);
                MessageBox.Show("Student updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}");
            }
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                _service.DeleteStudent(studentId);
                MessageBox.Show("Student deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}");
            }
        }

        public StudentDTO GetStudentById(int studentId)
        {
            try
            {
                return _service.GetStudentById(studentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving student: {ex.Message}");
                return null;
            }
        }

        public List<StudentDTO> GetAllStudents()
        {
            try
            {
                return _service.GetAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving students: {ex.Message}");
                return new List<StudentDTO>();
            }
        }
        public StudentDTO GetStudentByUserId(int userId)
        {
            return _service.GetStudentByUserId(userId);
        }

    }
}
