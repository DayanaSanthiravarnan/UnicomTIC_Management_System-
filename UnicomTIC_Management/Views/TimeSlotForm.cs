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
    public partial class TimeSlotForm : Form
    {
        private readonly TimeSlotController _controller;
        private int _selectedSlotId = -1;
        public TimeSlotForm()
        {
            InitializeComponent();

            _controller = new TimeSlotController(new TimeSlotService(new TimeSlotRepository()));

            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.CustomFormat = " hh:mm tt dd/MM/yyyy";
            dtpStartTime.ShowUpDown = false;

            tpEndTime.Format = DateTimePickerFormat.Custom;
            tpEndTime.CustomFormat = " hh:mm tt dd/MM/yyyy";
            tpEndTime.ShowUpDown = false;

            LoadTimeSlots();

        }
        private void LoadTimeSlots()
        {
            dgvTimeSlots.DataSource = _controller.GetAllTimeSlots();
            dgvTimeSlots.ClearSelection();
        }
        private void TimeSlotForm_Load(object sender, EventArgs e)
        {


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = tpEndTime.Value;
            DateTime now = DateTime.Now;

            if (startTime < now)
            {
                MessageBox.Show("Start time cannot be in the past.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be after start time.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new TimeSlotDTO
            {
                StartTime = startTime.ToString("dd/MM/yyyy hh:mm tt"),
                EndTime = endTime.ToString("dd/MM/yyyy hh:mm tt")
            };

            _controller.AddTimeSlot(dto);
            LoadTimeSlots();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedSlotId == -1)
            {
                MessageBox.Show("Please select a slot to update.");
                return;
            }

            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = tpEndTime.Value;
            DateTime now = DateTime.Now;

            if (startTime < now)
            {
                MessageBox.Show("Start time cannot be in the past.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be after start time.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new TimeSlotDTO
            {
                SlotID = _selectedSlotId,
                StartTime = startTime.ToString("dd/MM/yyyy hh:mm tt"),
                EndTime = endTime.ToString("dd/MM/yyyy hh:mm tt")
            };

            _controller.UpdateTimeSlot(dto);
            LoadTimeSlots();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSlotId == -1)
            {
                MessageBox.Show("Please select a slot to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _controller.DeleteTimeSlot(_selectedSlotId);
                LoadTimeSlots();
                ClearFields();
            }
        }

        private void dgvTimeSlots_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTimeSlots.SelectedRows.Count > 0)
            {
                var slot = dgvTimeSlots.SelectedRows[0].DataBoundItem as TimeSlotDTO;
                if (slot != null)
                {
                    _selectedSlotId = slot.SlotID;
                    dtpStartTime.Value = DateTime.Parse(slot.StartTime);
                    tpEndTime.Value = DateTime.Parse(slot.EndTime);
                }
            }
        }
        private void ClearFields()
        {
            _selectedSlotId = -1;
            dtpStartTime.Value = DateTime.Now;
            tpEndTime.Value = DateTime.Now.AddHours(1);
            dgvTimeSlots.ClearSelection();
        }
    }
}
