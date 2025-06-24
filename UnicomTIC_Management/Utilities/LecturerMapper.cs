using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UnicomTIC_Management.Utilities
{
    internal static class LecturerMapper
    {
        public static LecturerDTO ToDTO(Lecturer lecturer)
        {
            if (lecturer == null) return null;

            return new LecturerDTO
            {
                LecturerID = lecturer.LecturerID,
                Name = lecturer.Name,
                NIC = lecturer.NIC,
                Phone = lecturer.Phone,
                Address = lecturer.Address,
                Email = lecturer.Email,
                DepartmentID = lecturer.DepartmentID,
                DepartmentName = lecturer.DepartmentName,
                UserID = lecturer.UserID,
                
                CreatedAt = lecturer.CreatedAt,
                UpdatedAt = lecturer.UpdatedAt,
                Status = lecturer.Status
            };
        }

        public static Lecturer ToEntity(LecturerDTO dto)
        {
            if (dto == null) return null;

            return new Lecturer
            {
                LecturerID = dto.LecturerID,
                Name = dto.Name,
                NIC = dto.NIC,
                Phone = dto.Phone,
                Address = dto.Address,
                Email = dto.Email,
                DepartmentID = dto.DepartmentID,
                UserID = dto.UserID,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }

        public static List<LecturerDTO> ToDTOList(IEnumerable<Lecturer> lecturers)
        {
            return lecturers?.Select(ToDTO).ToList() ?? new List<LecturerDTO>();
        }

        public static List<Lecturer> ToEntityList(IEnumerable<LecturerDTO> dtos)
        {
            return dtos?.Select(ToEntity).ToList() ?? new List<Lecturer>();
        }
    }
}
    