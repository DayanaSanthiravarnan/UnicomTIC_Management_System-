using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IDepartmentService
    {
        void AddDepartment(DepartmentDTO departmentDTO);
        void UpdateDepartment(DepartmentDTO departmentDTO);
        void DeleteDepartment(int departmentId);
        DepartmentDTO GetDepartmentById(int departmentId);
        List<DepartmentDTO> GetAllDepartments();
    }
}
