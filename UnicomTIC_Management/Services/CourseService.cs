using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public void AddCourse(CourseDTO courseDTO)
        {
            if (courseDTO == null)
                throw new ArgumentNullException(nameof(courseDTO));
            if (string.IsNullOrWhiteSpace(courseDTO.CourseName))
                throw new ArgumentException("Course name is required.");

            var course = CourseMapper.ToEntity(courseDTO);
            _repository.AddCourse(course);
        }

        public void UpdateCourse(CourseDTO courseDTO)
        {
            if (courseDTO == null)
                throw new ArgumentNullException(nameof(courseDTO));
            if (courseDTO == null)
                throw new ArgumentException("Course name is required.");

            var course = CourseMapper.ToEntity(courseDTO);
            _repository.UpdateCourse(course);
        }

        public void DeleteCourse(int courseId)
        {
            _repository.DeleteCourse(courseId);
        }

        public CourseDTO GetCourseById(int courseId)
        {
            var course = _repository.GetCourseById(courseId);
            return CourseMapper.ToDTO(course);
        }

        public List<CourseDTO> GetAllCourses()
        {
            var courses = _repository.GetAllCourses();
            return CourseMapper.ToDTOList(courses);
        }
    }
}
