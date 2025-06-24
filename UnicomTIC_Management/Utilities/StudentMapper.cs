using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    public static class StudentMapper
    {
        public static StudentDTO ToDTO(Student student)
        {
            if (student == null)
                return null;

            return new StudentDTO
            {
                StudentID = student.StudentID,
                UserID = student.UserID,
                Name = student.Name,
                NIC = student.NIC,
                Email = student.Email,
                ContactNo = student.ContactNo,
                Gender = student.Gender,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth,
                EnrollmentDate = student.EnrollmentDate,
                CourseID = student.CourseID,
                MainGroupID = student.MainGroupID,
                SubGroupID = student.SubGroupID
            };
        }

        public static Student ToEntity(StudentDTO dto)
        {
            if (dto == null)
                return null;

            return new Student
            {
                StudentID = dto.StudentID,
                UserID = dto.UserID,
                Name = dto.Name,
                NIC = dto.NIC,
                Email = dto.Email,
                ContactNo = dto.ContactNo,
                Gender = dto.Gender,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                EnrollmentDate = dto.EnrollmentDate,
                CourseID = dto.CourseID,
                MainGroupID = dto.MainGroupID,
                SubGroupID = dto.SubGroupID
            };
        }

        public static List<StudentDTO> ToDTOList(List<Student> students)
        {
            if (students == null)
                return null;

            var list = new List<StudentDTO>();
            foreach (var s in students)
                list.Add(ToDTO(s));
            return list;
        }
    }
}

