using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class TimeSlotController
    {
        private readonly ITimeSlotService _service;

        public TimeSlotController(ITimeSlotService service)
        {
            _service = service;
        }

        public void AddTimeSlot(TimeSlotDTO dto)
        {
            try
            {
                _service.AddTimeSlot(dto);
                MessageBox.Show("Time slot added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding time slot: {ex.Message}");
            }
        }

        public void UpdateTimeSlot(TimeSlotDTO dto)
        {
            try
            {
                _service.UpdateTimeSlot(dto);
                MessageBox.Show("Time slot updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating time slot: {ex.Message}");
            }
        }

        public void DeleteTimeSlot(int slotId)
        {
            try
            {
                _service.DeleteTimeSlot(slotId);
                MessageBox.Show("Time slot deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting time slot: {ex.Message}");
            }
        }

        public TimeSlotDTO GetTimeSlotById(int slotId)
        {
            try
            {
                return _service.GetTimeSlotById(slotId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving time slot: {ex.Message}");
                return null;
            }
        }

        public List<TimeSlotDTO> GetAllTimeSlots()
        {
            try
            {
                return _service.GetAllTimeSlots();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving time slots: {ex.Message}");
                return new List<TimeSlotDTO>();
            }
        }
    }
}
