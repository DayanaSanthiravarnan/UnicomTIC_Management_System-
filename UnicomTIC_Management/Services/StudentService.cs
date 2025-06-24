using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public int AddStudent(StudentDTO studentDTO)
        {
            if (studentDTO == null)
                throw new ArgumentNullException(nameof(studentDTO));
            var student = StudentMapper.ToEntity(studentDTO);
            return _repository.CreateStudent(student);
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            if (studentDTO == null)
                throw new ArgumentNullException(nameof(studentDTO));
            if (string.IsNullOrWhiteSpace(studentDTO.Name))
                throw new ArgumentException("Student name is required.");

            var student = StudentMapper.ToEntity(studentDTO);
            _repository.UpdateStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            _repository.DeleteStudent(studentId);
        }

        public StudentDTO GetStudentById(int studentId)
        {
            var student = _repository.GetStudentById(studentId);
            return StudentMapper.ToDTO(student);
        }

        public List<StudentDTO> GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return StudentMapper.ToDTOList(students);
        }
        public StudentDTO GetStudentByUserId(int userId)
        {
            return _repository.GetStudentByUserId(userId);
        }
    }
}

