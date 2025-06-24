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
using System.Net.Mail;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Views
{
    internal partial class StaffDetailForm : Form
    {
        private readonly UserController _userController;
        private readonly StaffController _staffController;
        private readonly NICDetailController _nicController;
        private readonly DepartmentController _departmentController;

        private int staffIdToUpdate = 0;


        public StaffDetailForm()
        {
            InitializeComponent();

            _userController = new UserController(new UserService(new UserRepository()));
            _staffController = new StaffController(new StaffService(new StaffRepository()));
            _nicController = new NICDetailController(new NICDetailService(new NICDetailRepository()));
            _departmentController = new DepartmentController(new DepartmentService(new DepartmentRepository()));

            this.Load += StaffDetailForm_Load;
        }

        private void StaffDetailForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadStaffs();
            dgvStaffs.CellClick += dgvStaffs_CellClick;
        }
        private void LoadDepartments()
        {
            var departments = _departmentController.GetAllDepartments();
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
        }
            private void LoadStaffs()
        {
            var staffs = _staffController.GetAllStaff();
            dgvStaffs.DataSource = staffs;
            dgvStaffs.ClearSelection();
        }

        private void dgvStaffs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = (StaffDTO)dgvStaffs.Rows[e.RowIndex].DataBoundItem;
                LoadForUpdate(selected);
            }
        }
        public void LoadForUpdate(StaffDTO staff)
        {
            staffIdToUpdate = staff.StaffID;
            txtName.Text = staff.Name;
            txtNIC.Text = staff.NIC;
           
            txtContactNo.Text = staff.ContactNo;
            txtEmail.Text = staff.Email;

            if (staff.DepartmentID != null)
                cmbDepartment.SelectedValue = staff.DepartmentID;
            else
                cmbDepartment.SelectedIndex = -1;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!ValidateForm()) return;

            string nic = txtNIC.Text.Trim();

            try
            {
                if (staffIdToUpdate > 0)
                {
                    var staffDTO = new StaffDTO
                    {
                        StaffID = staffIdToUpdate,
                        Name = txtName.Text.Trim(),
                        NIC = nic,
                       
                        ContactNo = txtContactNo.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        DepartmentID = (int)cmbDepartment.SelectedValue,
                        UpdatedAt = DateTime.Now
                    };
                    _staffController.UpdateStaff(staffDTO);
                    MessageBox.Show("Staff updated successfully!");
                }
                else
                {
                    if (_nicController.IsNICUsed(nic))
                    {
                        MessageBox.Show("NIC already used.");
                        return;
                    }

                    var userDTO = new UserDTO
                    {
                        NIC = nic,
                        Role = UserRole.Staff,
                        Status = UserStatus.Accepted
                    };

                    int userId = _userController.CreateUser(userDTO);

                    var staffDTO = new StaffDTO
                    {
                        Name = txtName.Text.Trim(),
                        NIC = nic,
                        
                        ContactNo = txtContactNo.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        DepartmentID = (int)cmbDepartment.SelectedValue,
                        UserID = userId,
                        CreatedAt = DateTime.Now
                    };

                    _staffController.AddStaff(staffDTO);
                    _nicController.MarkAsUsed(nic);
                    MessageBox.Show("Staff added successfully!");
                }

                ClearForm();
                LoadStaffs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (staffIdToUpdate == 0)
            {
                MessageBox.Show("Please select a staff member to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this staff member?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _staffController.DeleteStaff(staffIdToUpdate);
                MessageBox.Show("Staff deleted successfully!");
                ClearForm();
                LoadStaffs();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearForm()
        {
            staffIdToUpdate = 0;
            txtName.Text = "";
            txtNIC.Text = "";
            txtContactNo.Text = "";
           
            txtEmail.Text = "";
            cmbDepartment.SelectedIndex = -1;
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNIC.Text)) { MessageBox.Show("NIC is required."); return false; }
            
            
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
