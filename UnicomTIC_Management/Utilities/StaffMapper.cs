using System.Collections.Generic;
using System.Linq;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    internal static class StaffMapper
    {
        public static StaffDTO ToDTO(Staff staff)
        {
            if (staff == null) return null;

            return new StaffDTO
            {
                StaffID = staff.StaffID,
                Name = staff.Name,
                NIC = staff.NIC,
                DepartmentID = staff.DepartmentID,
                ContactNo = staff.ContactNo,
                Email = staff.Email,
                UserID = staff.UserID,
                CreatedAt = staff.CreatedAt,
                UpdatedAt = staff.UpdatedAt
            };
        }

        public static Staff ToEntity(StaffDTO dto)
        {
            if (dto == null) return null;

            return new Staff
            {
                StaffID = dto.StaffID,
                Name = dto.Name,
                NIC = dto.NIC,
                DepartmentID = dto.DepartmentID,
                ContactNo = dto.ContactNo,
                Email = dto.Email,
                UserID = dto.UserID,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }

        public static List<StaffDTO> ToDTOList(IEnumerable<Staff> staffs)
        {
            return staffs?.Select(ToDTO).ToList() ?? new List<StaffDTO>();
        }

        public static List<Staff> ToEntityList(IEnumerable<StaffDTO> dtos)
        {
            return dtos?.Select(ToEntity).ToList() ?? new List<Staff>();
        }
    }
}
