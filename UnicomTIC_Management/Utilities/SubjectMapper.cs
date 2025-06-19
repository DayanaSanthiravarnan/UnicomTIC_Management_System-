using System;
using System.Collections.Generic;
using System.Linq;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    internal static class SubjectMapper
    {
        // Mapping from Subject to SubjectDTO
        public static SubjectDTO ToDTO(Subject subject)
        {
            if (subject == null) return null;

            return new SubjectDTO
            {
                SubjectID = subject.SubjectID,
                SubjectName = subject.SubjectName,
                CourseID = subject.CourseID,
                CourseName = subject.CourseName
            };
        }

        // Mapping from SubjectDTO back to Subject
        public static Subject ToEntity(SubjectDTO subjectDTO)
        {
            if (subjectDTO == null) return null;

            return new Subject
            {
                SubjectID = subjectDTO.SubjectID,
                SubjectName = subjectDTO.SubjectName,
                CourseID = subjectDTO.CourseID,
                CourseName = subjectDTO.CourseName
            };
        }

        // Mapping a list of Subject to a list of SubjectDTO
        public static List<SubjectDTO> ToDTOList(IEnumerable<Subject> subjects)
        {
            return subjects?.Select(ToDTO).ToList() ?? new List<SubjectDTO>();
        }

        // Mapping a list of SubjectDTO back to a list of Subject
        public static List<Subject> ToEntityList(IEnumerable<SubjectDTO> subjectDTOs)
        {
            return subjectDTOs?.Select(ToEntity).ToList() ?? new List<Subject>();
        }
        public static List<SubjectDTO> ToDTOList(List<Subject> subjects)
        {
            return subjects.Select(s => new SubjectDTO
            {
                SubjectID = s.SubjectID,
                SubjectName = s.SubjectName,
                CourseID = s.CourseID,
                CourseName = s.CourseName
            }).ToList();
        }
    }
}
