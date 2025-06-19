using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
   
        internal class DepartmentController
        {
            private readonly IDepartmentService _service;

            public DepartmentController(IDepartmentService service)
            {
                _service = service;
            }

            public void AddDepartment(DepartmentDTO departmentDTO)
            {
                try
                {
                    _service.AddDepartment(departmentDTO);
                    MessageBox.Show("Department added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding department: {ex.Message}");
                }
            }

            public void UpdateDepartment(DepartmentDTO departmentDTO)
            {
                try
                {
                    _service.UpdateDepartment(departmentDTO);
                    MessageBox.Show("Department updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating department: {ex.Message}");

                }
            }

            public void DeleteDepartment(int departmentId)
            {
                try
                {
                    _service.DeleteDepartment(departmentId);
                    MessageBox.Show("Department deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting department: {ex.Message}");

                }
            }

            public DepartmentDTO GetDepartmentById(int departmentId)
            {
                return _service.GetDepartmentById(departmentId);
            }

            public List<DepartmentDTO> GetAllDepartments()
            {
                return _service.GetAllDepartments();
            }
        }
    }

