using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities.UnicomTIC_Management.Mappers;

namespace UnicomTIC_Management.Controllers
{
    internal class NICDetailController
    {
        private readonly INICDetailService _service;

        public NICDetailController(INICDetailService service)
        {
            _service = service;
        }

        public void AddNIC(NICDetailDTO dto)
        {
            try
            {
                if (!_service.IsNICUsed(dto.NIC))
                {
                    _service.AddNIC(dto);
                    MessageBox.Show("NIC added successfully.");
                }
                else
                {
                    MessageBox.Show("This NIC is already used.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding NIC: {ex.Message}");
            }
        }

        public void MarkAsUsed(string nic)
        {
            try
            {
                _service.MarkNICAsUsed(nic);
                MessageBox.Show("NIC marked as used.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking NIC as used: {ex.Message}");
            }
        }

        public bool IsNICUsed(string nic)
        {
            try
            {
                return _service.IsNICUsed(nic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking NIC: {ex.Message}");
                return false;
            }
        }

        public NICDetailDTO GetByNIC(string nic)
        {
            try
            {
                // Service method already returns NICDetailDTO, no need to map again
                return _service.GetByNIC(nic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving NIC: {ex.Message}");
                return null;
            }
        }

        public List<NICDetailDTO> GetAllNICs()
        {
            try
            {
                // Correct method call to service
                return _service.GetAllNICs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving NIC list: {ex.Message}");
                return new List<NICDetailDTO>();
            }
        }
    }
}
    
