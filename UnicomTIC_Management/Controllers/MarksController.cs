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
    internal class MarksController
    {
        private readonly IMarksService _service;

        public MarksController(IMarksService service)
        {
            _service = service;
        }

        public void AddMark(MarksDTO markDTO)
        {
            try
            {
                _service.AddMark(markDTO);
                MessageBox.Show("Mark added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding mark: {ex.Message}");
            }
        }

        public void UpdateMark(MarksDTO markDTO)
        {
            try
            {
                _service.UpdateMark(markDTO);
                MessageBox.Show("Mark updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating mark: {ex.Message}");
            }
        }

        public void DeleteMark(int markId)
        {
            try
            {
                _service.DeleteMark(markId);
                MessageBox.Show("Mark deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting mark: {ex.Message}");
            }
        }

        public MarksDTO GetMarkById(int markId)
        {
            return _service.GetMarkById(markId);
        }

        public List<MarksDTO> GetAllMarks()
        {
            return _service.GetAllMarks();
        }
    }
}
