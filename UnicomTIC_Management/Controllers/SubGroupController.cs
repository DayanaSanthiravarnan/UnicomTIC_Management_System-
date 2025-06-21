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

        public void AddSubGroup(SubGroupDTO dto)
        {
            try
            {
                _service.AddSubGroup(dto);
                MessageBox.Show("SubGroup added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding SubGroup: " + ex.Message);
            }
        }

        public void UpdateSubGroup(SubGroupDTO dto)
        {
            try
            {
                _service.UpdateSubGroup(dto);
                MessageBox.Show("SubGroup updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating SubGroup: " + ex.Message);
            }
        }

        public void DeleteSubGroup(int id)
        {
            try
            {
                _service.DeleteSubGroup(id);
                MessageBox.Show("SubGroup deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting SubGroup: " + ex.Message);
            }
        }

        public SubGroupDTO GetSubGroupById(int id)
        {
            return _service.GetSubGroupById(id);
        }

        public List<SubGroupDTO> GetAllSubGroups()
        {
            return _service.GetAllSubGroups();
        }

        public List<SubGroupDTO> GetSubGroupsByMainGroupId(int mainGroupId)
        {
            return _service.GetSubGroupsByMainGroupId(mainGroupId);
        }
        public int CreateSubGroup(SubGroupDTO dto)
        {
            return _service.CreateSubGroup(dto);
        }
    }
}
