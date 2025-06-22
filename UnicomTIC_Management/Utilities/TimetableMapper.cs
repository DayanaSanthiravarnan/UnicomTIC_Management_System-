using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    internal static class TimetableMapper
    {
        public static TimeTable ToEntity(TimetableDTO dto)
        {
            if (dto == null) return null;
            return new TimeTable
            {
                TimetableID = dto.TimetableID,
                CourseID = dto.CourseID,
                SubjectID = dto.SubjectID,
                LecturerID = dto.LecturerID,
                RoomID = dto.RoomID,
                SlotID = dto.SlotID,
                MainGroupID = dto.MainGroupID,
                SubGroupID = dto.SubGroupID,
                DayOfWeek = dto.DayOfWeek,
                AcademicYear = dto.AcademicYear,
                Semester = dto.Semester
            };
        }

        public static TimetableDTO ToDTO(TimeTable entity)
        {
            if (entity == null) return null;
            return new TimetableDTO
            {
                TimetableID = entity.TimetableID,
                CourseID = entity.CourseID,
                SubjectID = entity.SubjectID,
                LecturerID = entity.LecturerID,
                RoomID = entity.RoomID,
                SlotID = entity.SlotID,
                MainGroupID = entity.MainGroupID,
                SubGroupID = entity.SubGroupID,
                DayOfWeek = entity.DayOfWeek,
                AcademicYear = entity.AcademicYear,
                Semester = entity.Semester
            };
        }

        public static List<TimetableDTO> ToDTOList(IEnumerable<TimeTable> entities)
        {
            return entities?.Select(ToDTO).ToList() ?? new List<TimetableDTO>();
        }
    }
}
