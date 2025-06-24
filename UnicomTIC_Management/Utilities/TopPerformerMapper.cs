using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    internal static class TopPerformerMapper
    {
        public static TopPerformerDTO ToDTO(TopPerformer tp) => new TopPerformerDTO
        {
            TopPerformerID = tp.TopPerformerID,
            StudentID = tp.StudentID,
            StudentName = tp.StudentName,
            ExamID = tp.ExamID,
            ExamName = tp.ExamName,
            MarksObtained = tp.MarksObtained,
            Grade = tp.Grade,
            RecordedDate = tp.RecordedDate
        };

        public static List<TopPerformerDTO> ToDTOList(List<TopPerformer> list) =>
            list.Select(ToDTO).ToList();

        public static TopPerformer ToEntity(TopPerformerDTO dto) => new TopPerformer
        {
            TopPerformerID = dto.TopPerformerID,
            StudentID = dto.StudentID,
            ExamID = dto.ExamID,
            MarksObtained = dto.MarksObtained,
            Grade = dto.Grade,
            RecordedDate = dto.RecordedDate
        };
    }
}
