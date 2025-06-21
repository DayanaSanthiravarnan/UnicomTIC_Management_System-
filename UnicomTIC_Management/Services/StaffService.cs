using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;

        public StaffService(IStaffRepository repository)
        {
            _repository = repository;
        }

        public int AddStaff(StaffDTO staffDTO)
        {
            if (staffDTO == null)
                throw new ArgumentNullException(nameof(staffDTO));

            var staff = StaffMapper.ToEntity(staffDTO);
            return _repository.CreateStaff(staff);
        }

        public void UpdateStaff(StaffDTO staffDTO)
        {
            if (staffDTO == null)
                throw new ArgumentNullException(nameof(staffDTO));
            if (string.IsNullOrWhiteSpace(staffDTO.Name))
                throw new ArgumentException("Staff name is required.");

            var staff = StaffMapper.ToEntity(staffDTO);
            _repository.UpdateStaff(staff);
        }

        public void DeleteStaff(int staffId)
        {
            _repository.DeleteStaff(staffId);
        }

        public StaffDTO GetStaffById(int staffId)
        {
            var staff = _repository.GetStaffById(staffId);
            return StaffMapper.ToDTO(staff);
        }

        public List<StaffDTO> GetAllStaff()
        {
            var staffList = _repository.GetAllStaff();
            return StaffMapper.ToDTOList(staffList);
        }
    }
}
