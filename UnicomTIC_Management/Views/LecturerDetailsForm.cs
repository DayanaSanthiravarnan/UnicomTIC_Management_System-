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
using UnicomTIC_Management.Repositories.UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using System.Net.Mail;

namespace UnicomTIC_Management.Views
{
    internal partial class LecturerDetailsForm : Form
    {
        private readonly UserController _userController;
        private readonly LecturerController _lecturerController;
        private readonly NICDetailController _nicController;
        private readonly DepartmentController _departmentController;

        private int lecturerIdToUpdate = 0;


        public LecturerDetailsForm()
        {
            InitializeComponent();

            _userController = new UserController(new UserService(new UserRepository()));
            _lecturerController = new LecturerController(new LecturerService(new LecturerRepository()));
            _nicController = new NICDetailController(new NICDetailService(new NICDetailRepository()));
            _departmentController = new DepartmentController(new DepartmentService(new DepartmentRepository()));

            this.Load += LecturerDetailsForm_Load;
        }


        private void LecturerDetailsForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadLecturers();
            dgvLecturers.CellClick += dgvLecturers_CellClick;

        }
        private void LoadDepartments()
        {
            var departments = _departmentController.GetAllDepartments();
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
        }

        private void LoadLecturers()
        {
            var lecturers = _lecturerController.GetAllLecturers();
            dgvLecturers.DataSource = lecturers;
            dgvLecturers.ClearSelection();
        }

        private void dgvLecturers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = (LecturerDTO)dgvLecturers.Rows[e.RowIndex].DataBoundItem;
                LoadForUpdate(selected);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string nicInput = txtNIC.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contact = txtPhone.Text.Trim();

            try
            {
                if (lecturerIdToUpdate > 0)
                {
                    var lecturerDTO = new LecturerDTO
                    {
                        LecturerID = lecturerIdToUpdate,
                        Name = txtName.Text.Trim(),
                        NIC = nicInput,
                        Address = txtAddress.Text.Trim(),
                        Email = email,
                        Phone = contact,
                        DepartmentID = (int)cmbDepartment.SelectedValue,
                        UpdatedAt = DateTime.Now
                    };
                    _lecturerController.UpdateLecturer(lecturerDTO);
                    MessageBox.Show("Lecturer updated successfully!");
                }
                else
                {

                    if (_nicController.IsNICUsed(nicInput))
                    {
                        MessageBox.Show("NIC already used.");
                        return;
                    }

                    var userDTO = new UserDTO
                    {


                        NIC = nicInput,
                        Role = UserRole.Lecturer,
                        Status = UserStatus.Accepted
                    };
                    int userId = _userController.CreateUser(userDTO);

                    var lecturerDTO = new LecturerDTO
                    {
                        Name = txtName.Text.Trim(),
                        NIC = nicInput,
                        Address = txtAddress.Text.Trim(),
                        Email = email,
                        Phone = contact,
                        DepartmentID = (int)cmbDepartment.SelectedValue,
                        UserID = userId,
                        CreatedAt = DateTime.Now
                    };
                    int lecturerId = _lecturerController.AddLecturer(lecturerDTO);
                    _nicController.MarkAsUsed(nicInput);
                    MessageBox.Show("Lecturer registered successfully!");
                }

                ClearForm();
                LoadLecturers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void LoadForUpdate(LecturerDTO lecturer)
        {
            lecturerIdToUpdate = lecturer.LecturerID;
            txtName.Text = lecturer.Name;
            txtNIC.Text = lecturer.NIC;
            txtAddress.Text = lecturer.Address;
            txtEmail.Text = lecturer.Email;
            txtPhone.Text = lecturer.Phone;
            if (lecturer.DepartmentID != null && cmbDepartment.Items.Cast<object>().Any(item => ((DataRowView)item).Row.Field<int>("DepartmentID") == lecturer.DepartmentID))
            {
                cmbDepartment.SelectedValue = lecturer.DepartmentID;
            }
            else
            {
                cmbDepartment.SelectedIndex = -1; // or show error/log
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lecturerIdToUpdate == 0)
            {
                MessageBox.Show("Please select a lecturer to delete.");
                return;
            }
            var confirm = MessageBox.Show("Are you sure to delete this lecturer?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _lecturerController.DeleteLecturer(lecturerIdToUpdate);
                MessageBox.Show("Lecturer deleted successfully!");
                ClearForm();
                LoadLecturers();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearForm()
        {

            lecturerIdToUpdate = 0;
            txtUsername.Text = "";

            txtName.Text = "";
            txtNIC.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            cmbDepartment.SelectedIndex = -1;
            txtUsername.Enabled = true;


        }
        private bool ValidateForm()
        {


            if (string.IsNullOrWhiteSpace(txtNIC.Text)) { MessageBox.Show("NIC is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text.Trim().Length < 5) { MessageBox.Show("Address is required."); return false; }
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || !txtPhone.Text.All(char.IsDigit) || txtPhone.Text.Length != 10) { MessageBox.Show("Phone must be 10 digits."); return false; }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try { var addr = new MailAddress(txtEmail.Text.Trim()); if (addr.Address != txtEmail.Text.Trim()) throw new FormatException(); }
                catch { MessageBox.Show("Invalid email address."); return false; }
            }
            if (cmbDepartment.SelectedValue == null) { MessageBox.Show("Please select a Department."); return false; }
            return true;
        }
    }
}
