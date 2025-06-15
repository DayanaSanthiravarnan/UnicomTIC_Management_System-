using System;
using System.Collections.Generic;
using System.Linq;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    internal static class ExamMapper
    {
        
        public static ExamDTO ToDTO(Exam exam)
        {
            if (exam == null) return null;

            return new ExamDTO
            {
                ExamID = exam.ExamsID,
                ExamName = exam.ExamsName,
                SubjectID = exam.SubjectID,
                SubjectName = exam.SubjectName,
                ExamDate = exam.ExamDate,
                ExamType = exam.ExamType,
                MaxMarks = exam.MaxMarks
            };
        }

        
        public static Exam ToEntity(ExamDTO examDTO)
        {
            if (examDTO == null) return null;

            return new Exam
            {
                ExamsID = examDTO.ExamID,
                ExamsName = examDTO.ExamName,
                SubjectID = examDTO.SubjectID,
                SubjectName = examDTO.SubjectName,
                ExamDate = examDTO.ExamDate,
                ExamType = examDTO.ExamType,
                MaxMarks = examDTO.MaxMarks
            };
        }

        
        public static List<ExamDTO> ToDTOList(IEnumerable<Exam> exams)
        {
            return exams?.Select(ToDTO).ToList() ?? new List<ExamDTO>();
        }

        
        public static List<Exam> ToEntityList(IEnumerable<ExamDTO> examDTOs)
        {
            return examDTOs?.Select(ToEntity).ToList() ?? new List<Exam>();
        }
    }
}


