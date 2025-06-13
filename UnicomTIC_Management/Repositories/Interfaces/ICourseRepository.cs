using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface ICourseRepository
    {
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int courseId);
        Course GetCourseById(int courseId);
        List<Course> GetAllCourses();
    }
}
