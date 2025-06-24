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
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Views
{
    internal partial class AttendanceForm : Form
    {
        private readonly AttendanceController _attendanceController;
        private readonly StudentController _studentController;

        private int selectedAttendanceId = -1;
        public AttendanceForm(AttendanceController attendanceController, StudentController studentController)
        {
            InitializeComponent();
            _attendanceController = attendanceController;
            _studentController = studentController;
        }

        private void btnSubmitAttendance_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            var studentId = (int)cmbStudent.SelectedValue;
            var date = dtpDate.Value.ToString("yyyy-MM-dd");
            var status = cmbStatus.SelectedItem.ToString();

            // Check if attendance already marked
            if (_attendanceController.IsAttendanceMarked(studentId, date))
            {
                MessageBox.Show("Attendance already marked for this student on this date.");
                return;
            }

            var dto = new AttendanceDTO
            {
                StudentID = studentId,
                Date = date,
                Status = status
            };

            _attendanceController.AddAttendance(dto);
            MessageBox.Show("Attendance marked successfully!");

            LoadAttendanceGrid();
            ClearForm();
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAttendance.Rows[e.RowIndex];

                selectedAttendanceId = Convert.ToInt32(row.Cells["AttendanceID"].Value);
                cmbStudent.SelectedValue = row.Cells["StudentID"].Value;
                dtpDate.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnMarkAttendance.Enabled = false;
            }
        }
    

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Present", "Absent", "Late", "Excused" });
            cmbStatus.SelectedIndex = 0;

            dtpDate.Value = DateTime.Today;

            LoadAttendanceGrid();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void LoadStudents()
        {
            var students = _studentController.GetAllStudents();
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "Name";
            cmbStudent.ValueMember = "StudentID";
            cmbStudent.SelectedIndex = -1;
        }
        private void LoadAttendanceGrid()
        {
            var data = _attendanceController.GetAllAttendances();
            dgvAttendance.DataSource = data;

            dgvAttendance.Columns["AttendanceID"].Visible = false;
        }
        private void ClearForm()
        {
            cmbStudent.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;

            selectedAttendanceId = -1;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnMarkAttendance.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAttendanceId == -1)
            {
                MessageBox.Show("Please select an attendance record to update.");
                return;
            }

            var dto = new AttendanceDTO
            {
                AttendanceID = selectedAttendanceId,
                StudentID = (int)cmbStudent.SelectedValue,
                Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                Status = cmbStatus.SelectedItem.ToString()
            };

            _attendanceController.UpdateAttendance(dto);
            MessageBox.Show("Attendance updated successfully.");

            LoadAttendanceGrid();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAttendanceId == -1)
            {
                MessageBox.Show("Please select an attendance record to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this attendance record?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                _attendanceController.DeleteAttendance(selectedAttendanceId);
                MessageBox.Show("Attendance deleted successfully.");

                LoadAttendanceGrid();
                ClearForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
