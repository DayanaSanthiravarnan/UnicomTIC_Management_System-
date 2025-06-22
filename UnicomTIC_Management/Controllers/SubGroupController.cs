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
    internal class SubGroupController
    {
        private readonly ISubGroupService _service;

        public SubGroupController(ISubGroupService service)
        {
            _service = service;
        }

        public int AddSubGroup(SubGroupDTO dto)
        {
            try
            {
                return _service.AddSubGroup(dto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subgroup: {ex.Message}");
                return -1;  // or throw or some error code you prefer
            }
        }

        public void UpdateSubGroup(SubGroupDTO dto)
        {
            try
            {
                _service.UpdateSubGroup(dto);
                MessageBox.Show("SubGroup updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating subgroup: {ex.Message}");
            }
        }

        public void DeleteSubGroup(int subGroupId)
        {
            try
            {
                _service.DeleteSubGroup(subGroupId);
                MessageBox.Show("SubGroup deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting subgroup: {ex.Message}");
            }
        }

        public SubGroupDTO GetSubGroupById(int subGroupId)
        {
            try
            {
                return _service.GetSubGroupById(subGroupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving subgroup: {ex.Message}");
                return null;
            }
        }

        public List<SubGroupDTO> GetAllSubGroups()
        {
            try
            {
                return _service.GetAllSubGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving subgroups: {ex.Message}");
                return new List<SubGroupDTO>();
            }
        }

        public List<SubGroupDTO> GetSubGroupsByMainGroupId(int mainGroupId)
        {
            try
            {
                return _service.GetSubGroupsByMainGroupId(mainGroupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving subgroups by main group: {ex.Message}");
                return new List<SubGroupDTO>();
            }
        }
    }
}
