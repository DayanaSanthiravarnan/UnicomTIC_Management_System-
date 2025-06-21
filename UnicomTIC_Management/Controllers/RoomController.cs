using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class RoomController
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        public void AddRoom(RoomDTO roomDTO)
        {
            try
            {
                _service.AddRoom(roomDTO);
                MessageBox.Show("Room added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}");
            }
        }

        public void UpdateRoom(RoomDTO roomDTO)
        {
            try
            {
                _service.UpdateRoom(roomDTO);
                MessageBox.Show("Room updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}");
            }
        }

        public void DeleteRoom(int roomId)
        {
            try
            {
                _service.DeleteRoom(roomId);
                MessageBox.Show("Room deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting room: {ex.Message}");
            }
        }

        public RoomDTO GetRoomById(int roomId)
        {
            return _service.GetRoomById(roomId);
        }

        public List<RoomDTO> GetAllRooms()
        {
            return _service.GetAllRooms();
        }
    }
}
