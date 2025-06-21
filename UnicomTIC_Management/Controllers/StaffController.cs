using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class StaffController

    {
        private readonly IStaffService _service;

        public StaffController(IStaffService service)
        {
            _service = service;
        }

        // Adds a new staff member and returns the new staff ID
        public int AddStaff(StaffDTO staffDTO)
        {
            try
            {
                return _service.AddStaff(staffDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding staff: {ex.Message}");
                return -1;
            }
        }

        public void UpdateStaff(StaffDTO staffDTO)
        {
            try
            {
                _service.UpdateStaff(staffDTO);
                MessageBox.Show("Staff updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating staff: {ex.Message}");
            }
        }

        public void DeleteStaff(int staffId)
        {
            try
            {
                _service.DeleteStaff(staffId);
                MessageBox.Show("Staff deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting staff: {ex.Message}");
            }
        }

        public StaffDTO GetStaffById(int staffId)
        {
            try
            {
                return _service.GetStaffById(staffId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving staff: {ex.Message}");
                return null;
            }
        }

        public List<StaffDTO> GetAllStaff()
        {
            try
            {
                return _service.GetAllStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving staff list: {ex.Message}");
                return new List<StaffDTO>();
            }
        }
    }
}
