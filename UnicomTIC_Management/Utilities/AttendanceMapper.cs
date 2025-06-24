using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    
        internal static class AttendanceMapper
        {
            // Convert Attendance entity to AttendanceDTO
            public static AttendanceDTO ToDTO(Attendance attendance)
            {
                if (attendance == null) return null;

                return new AttendanceDTO
                {
                    AttendanceID = attendance.AttendanceID,
                    StudentID = attendance.StudentID,
                    Date = attendance.Date,
                    SubjectID = attendance.SubjectID,
                    TimeSlot = attendance.TimeSlot,
                    Status = attendance.Status
                };
            }

            // Convert AttendanceDTO to Attendance entity
            public static Attendance ToEntity(AttendanceDTO dto)
            {
                if (dto == null) return null;

                return new Attendance
                {
                    AttendanceID = dto.AttendanceID,
                    StudentID = dto.StudentID,
                    Date = dto.Date,
                    SubjectID = dto.SubjectID,
                    TimeSlot = dto.TimeSlot,
                    Status = dto.Status
                };
            }

            // Convert list of Attendance entities to list of DTOs
            public static List<AttendanceDTO> ToDTOList(IEnumerable<Attendance> attendances)
            {
                return attendances?.Select(ToDTO).ToList() ?? new List<AttendanceDTO>();
            }

            // Convert list of DTOs back to Attendance entities
            public static List<Attendance> ToEntityList(IEnumerable<AttendanceDTO> dtos)
            {
                return dtos?.Select(ToEntity).ToList() ?? new List<Attendance>();
            }
        }
    }

