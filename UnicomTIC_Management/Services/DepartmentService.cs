using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public void AddDepartment(DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null)
                throw new ArgumentNullException(nameof(departmentDTO));

            if (string.IsNullOrWhiteSpace(departmentDTO.DepartmentName))
                throw new ArgumentException("Department name is required.");

            var department = DepartmentMapper.ToEntity(departmentDTO);
            _repository.AddDepartment(department);
        }

        public void UpdateDepartment(DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null)
                throw new ArgumentNullException(nameof(departmentDTO));

            if (string.IsNullOrWhiteSpace(departmentDTO.DepartmentName))
                throw new ArgumentException("Department name is required.");

            var department = DepartmentMapper.ToEntity(departmentDTO);
            _repository.UpdateDepartment(department);
        }

        public void DeleteDepartment(int departmentId)
        {
            _repository.DeleteDepartment(departmentId);
        }

        public DepartmentDTO GetDepartmentById(int departmentId)
        {
            var department = _repository.GetDepartmentById(departmentId);
            return DepartmentMapper.ToDTO(department);
        }

        public List<DepartmentDTO> GetAllDepartments()
        {
            var departments = _repository.GetAllDepartments();
            return DepartmentMapper.ToDTOList(departments);
        }
    }
}

