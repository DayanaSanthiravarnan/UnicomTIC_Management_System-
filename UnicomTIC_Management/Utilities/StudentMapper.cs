using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
   
        public static class StudentMapper
        {
            
            public static StudentDTO Map(DataRow row)
            {
                if (row == null)
                    return null;

                return new StudentDTO
                {
                    StudentID = row.Field<int>("StudentID"),
                    Name = row.Field<string>("Name"),
                    NIC = row.Field<string>("NIC"),
                    Address = row.Field<string>("Address"),
                    ContactNo = row.Field<string>("ContactNo"),
                    Email = row.Field<string>("Email"),
                    DateOfBirth = row.Field<DateTime?>("DateOfBirth"),
                    Gender = row.Field<string>("Gender"),
                    EnrollmentDate = row.Field<DateTime>("EnrollmentDate"),
                    CourseID = row.Field<int>("CourseID"),
                    UserID = row.Field<int>("UserID"),
                    MainGroupID = row.Field<int>("MainGroupID"),
                    SubGroupID = row.Field<int>("SubGroupID"),
                    CreatedAt = row.Field<DateTime>("CreatedAt"),
                    UpdatedAt = row.Field<DateTime>("UpdatedAt"),
                };
            }

            // Convert Student entity to StudentDTO
            public static StudentDTO ToDTO(Student student)
            {
                if (student == null)
                    return null;

                return new StudentDTO
                {
                    StudentID = student.StudentID,
                    Name = student.Name,
                    NIC = student.NIC,
                    Address = student.Address,
                    ContactNo = student.ContactNo,
                    Email = student.Email,
                    DateOfBirth = student.DateOfBirth,
                    Gender = student.Gender,
                    EnrollmentDate = student.EnrollmentDate,
                    CourseID = student.CourseID,
                    UserID = student.UserID,
                    MainGroupID = student.MainGroupID,
                    SubGroupID = student.SubGroupID,
                    CreatedAt = student.CreatedAt,
                    UpdatedAt = student.UpdatedAt
                };
            }

            // Convert StudentDTO to Student entity
            public static Student ToEntity(StudentDTO dto)
            {
                if (dto == null)
                    return null;

                return new Student
                {
                    StudentID = dto.StudentID,
                    Name = dto.Name,
                    NIC = dto.NIC,
                    Address = dto.Address,
                    ContactNo = dto.ContactNo,
                    Email = dto.Email,
                    DateOfBirth = dto.DateOfBirth,
                    Gender = dto.Gender,
                    EnrollmentDate = dto.EnrollmentDate,
                    CourseID = dto.CourseID,
                    UserID = dto.UserID,
                    MainGroupID = dto.MainGroupID,
                    SubGroupID = dto.SubGroupID,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt
                };
            }

            // Convert List<Student> to List<StudentDTO>
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

