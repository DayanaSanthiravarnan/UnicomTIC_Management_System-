using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
        void DeleteStudent(int studentId);
        StudentDTO GetStudentById(int studentId);
        List<StudentDTO> GetAllStudents();
    }
}
