using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
   internal static class MarksMapper
    {
        public static MarksDTO ToDTO(Marks mark)
        {
            if (mark == null) return null;

            return new MarksDTO
            {
                MarkID = mark.MarkID,
                StudentID = mark.StudentID,
                StudentName = mark.StudentName,    // assuming Marks has these properties
                SubjectID = mark.SubjectID,
                SubjectName = mark.SubjectName,
                ExamID = mark.ExamID,
                ExamName = mark.ExamName,
                MarksObtained = mark.MarksObtained,
                Grade = mark.Grade
            };
        }

        public static Marks ToEntity(MarksDTO dto)
        {
            if (dto == null) return null;

            return new Marks
            {
                MarkID = dto.MarkID,
                StudentID = dto.StudentID,
                StudentName = dto.StudentName,   // optional if used
                SubjectID = dto.SubjectID,
                SubjectName = dto.SubjectName,   // optional if used
                ExamID = dto.ExamID,
                ExamName = dto.ExamName,         // optional if used
                MarksObtained = dto.MarksObtained,
                Grade = dto.Grade
            };
        }

        public static List<MarksDTO> ToDTOList(List<Marks> marksList)
        {
            return marksList?.Select(ToDTO).ToList() ?? new List<MarksDTO>();
        }

        public static List<Marks> ToEntityList(List<MarksDTO> dtoList)
        {
            return dtoList?.Select(ToEntity).ToList() ?? new List<Marks>();
        }
    }
}
