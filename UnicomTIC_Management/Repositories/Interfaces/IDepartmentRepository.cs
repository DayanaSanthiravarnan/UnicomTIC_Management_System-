using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IDepartmentRepository
    {
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
        Department GetDepartmentById(int departmentId);
        List<Department> GetAllDepartments();
    }
}
