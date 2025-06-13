using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    internal static class CourseMapper
    {
        // Map Course to CourseDTO
        public static CourseDTO ToDTO(Course course)
        {
            if (course == null) return null;
            return new CourseDTO
            {
                CourseID = course.CourseID, // Respecting typo in Course model
                CourseName = course.CourseName,
                Description = course.CourseDescription
            };
        }

        // Map CourseDTO to Course
        public static Course ToEntity(CourseDTO courseDTO)
        {
            if (courseDTO == null) return null;
            return new Course
            {
                CourseID = courseDTO.CourseID,
                CourseName = courseDTO.CourseName,
                CourseDescription = courseDTO.Description
            };
        }

        // Map List of Course to List of CourseDTO
        public static List<CourseDTO> ToDTOList(IEnumerable<Course> courses)
        {
            return courses?.Select(c => ToDTO(c)).ToList() ?? new List<CourseDTO>();
        }

        // Map List of CourseDTO to List of Course
        public static List<Course> ToEntityList(IEnumerable<CourseDTO> courseDTOs)
        {
            return courseDTOs?.Select(c => ToEntity(c)).ToList() ?? new List<Course>();
        }
    }
}
