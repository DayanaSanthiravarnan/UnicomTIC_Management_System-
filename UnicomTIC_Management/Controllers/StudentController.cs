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
   public class StudentController
    {
      
            private readonly IStudentService _service;

            public StudentController(IStudentService service)
            {
                _service = service;
            }

            public void AddStudent(StudentDTO studentDTO)
            {
                try
                {
                    _service.AddStudent(studentDTO);
                    MessageBox.Show("Student added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding student: {ex.Message}");
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
        }
    
}
