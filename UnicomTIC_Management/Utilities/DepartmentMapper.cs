using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    
    internal static class DepartmentMapper
    {
        // To DTO
        public static DepartmentDTO ToDTO(Department department)
        {
            if (department == null) return null;

            return new DepartmentDTO
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName
            };
        }

        // To Entity
        public static Department ToEntity(DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null) return null;

            return new Department
            {
                DepartmentID = departmentDTO.DepartmentID,
                DepartmentName = departmentDTO.DepartmentName
            };
        }

        // List Mapping
        public static List<DepartmentDTO> ToDTOList(IEnumerable<Department> departments)
        {
            return departments?.Select(ToDTO).ToList() ?? new List<DepartmentDTO>();
        }

        public static List<Department> ToEntityList(IEnumerable<DepartmentDTO> departmentDTOs)
        {
            return departmentDTOs?.Select(ToEntity).ToList() ?? new List<Department>();
        }
    }
}
