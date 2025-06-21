using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;

namespace UnicomTIC_Management.Views
{
    public partial class RoomManagementForm : Form
    {
        private readonly RoomController _controller;
        private int _roomId = -1;

        public RoomManagementForm()
        {
            _controller = new RoomController(new RoomService(new RoomRepository()));
            InitializeComponent();
            LoadRooms();

        }

        private void RoomManagementForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadRooms()
        {
            try
            {
                var rooms = _controller.GetAllRooms();
                var grid = this.Controls.Find("dgvRooms", true)[0] as DataGridView;
                grid.DataSource = rooms;
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var roomDTO = new RoomDTO
                {
                    RoomName = this.Controls.Find("txtRoomName", true)[0].Text
                };

                _controller.AddRoom(roomDTO);
                LoadRooms();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_roomId == -1)
                {
                    MessageBox.Show("Please select a room to update.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var roomDTO = new RoomDTO
                {
                    RoomID = _roomId,
                    RoomName = this.Controls.Find("txtRoomName", true)[0].Text
                };

                _controller.UpdateRoom(roomDTO);
                LoadRooms();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_roomId == -1)
                {
                    MessageBox.Show("Please select a room to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _controller.DeleteRoom(_roomId);
                    LoadRooms();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            var grid = this.Controls.Find("dgvRooms", true)[0] as DataGridView;
            if (grid.SelectedRows.Count > 0)
            {
                var roomDTO = grid.SelectedRows[0].DataBoundItem as RoomDTO;
                if (roomDTO != null)
                {
                    _roomId = roomDTO.RoomID;
                    this.Controls.Find("txtRoomName", true)[0].Text = roomDTO.RoomName;
                }
            }
        }
        private void ClearFields()
        {
            _roomId = -1;
            this.Controls.Find("txtRoomName", true)[0].Text = "";
        }
    }
}
