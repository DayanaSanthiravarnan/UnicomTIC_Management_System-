using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ICourseService
    {
        void AddCourse(CourseDTO courseDTO);
        void UpdateCourse(CourseDTO courseDTO);
        void DeleteCourse(int courseId);
        CourseDTO GetCourseById(int courseId);
        List<CourseDTO> GetAllCourses();
    }
}
