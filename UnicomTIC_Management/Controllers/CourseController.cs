using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class CourseController
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        public void AddCourse(CourseDTO courseDTO)
        {
            try
            {
                _service.AddCourse(courseDTO);
                MessageBox.Show("Course added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}");
            }
        }

        public void UpdateCourse(CourseDTO courseDTO)
        {
            try
            {
                _service.UpdateCourse(courseDTO);
                MessageBox.Show("Course updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}");
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                _service.DeleteCourse(courseId);
                MessageBox.Show("Course deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}");
            }
        }

        public CourseDTO GetCourseById(int courseId)
        {
            return _service.GetCourseById(courseId);
        }

        public List<CourseDTO> GetAllCourses()
        {
            return _service.GetAllCourses();
        }
    }
}
