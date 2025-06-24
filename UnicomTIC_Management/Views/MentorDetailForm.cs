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
    internal partial class MentorDetailForm : Form
    {
        private readonly UserController _userController;
        private readonly MentorController _mentorController;
        private readonly NICDetailController _nicController;
        private readonly DepartmentController _departmentController;

        private int mentorIdToUpdate = 0;
        public MentorDetailForm()
        {
            InitializeComponent();

            _userController = new UserController(new UserService(new UserRepository()));
            _mentorController = new MentorController(new MentorService(new MentorRepository()));
            _nicController = new NICDetailController(new NICDetailService(new NICDetailRepository()));
            _departmentController = new DepartmentController(new DepartmentService(new DepartmentRepository()));

            this.Load += MentorDetailForm_Load;
        }

        private void MentorDetailForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadMentors();
            dgvMentors.CellClick += dgvMentors_CellClick;
        }
        private void LoadDepartments()
        {
            var departments = _departmentController.GetAllDepartments();
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
        }

        private void LoadMentors()
        {
            var mentors = _mentorController.GetAllMentors();
            dgvMentors.DataSource = mentors;
            dgvMentors.ClearSelection();
        }

        private void dgvMentors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = (MentorDTO)dgvMentors.Rows[e.RowIndex].DataBoundItem;
                LoadForUpdate(selected);
            }
        }
        public void LoadForUpdate(MentorDTO mentor)
        {
            mentorIdToUpdate = mentor.MentorID;
            txtName.Text = mentor.Name;
            txtNIC.Text = mentor.NIC;
            txtContact.Text = mentor.Phone;
            txtEmail.Text = mentor.Email;

            if (mentor.DepartmentID != null)
                cmbDepartment.SelectedValue = mentor.DepartmentID;
            else
                cmbDepartment.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string nic = txtNIC.Text.Trim();

            try
            {
                if (mentorIdToUpdate > 0)
                {
                    var mentorDTO = new MentorDTO
                    {
                        MentorID = mentorIdToUpdate,
                        Name = txtName.Text.Trim(),
                        NIC = nic,
                        Phone = txtContact.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        DepartmentID = (int)cmbDepartment.SelectedValue,
                        UpdatedAt = DateTime.Now
                    };

                    _mentorController.UpdateMentor(mentorDTO);
                    MessageBox.Show("Mentor updated successfully!");
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
                        Role = UserRole.Mentor,
                        Status = UserStatus.Accepted
                    };

                    int userId = _userController.CreateUser(userDTO);

                    var mentorDTO = new MentorDTO
                    {
                        Name = txtName.Text.Trim(),
                        NIC = nic,
                        Phone = txtContact.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        DepartmentID = (int)cmbDepartment.SelectedValue,
                        UserID = userId,
                        CreatedAt = DateTime.Now
                    };

                    _mentorController.AddMentor(mentorDTO);
                    _nicController.MarkAsUsed(nic);
                    MessageBox.Show("Mentor registered successfully!");
                }

                ClearForm();
                LoadMentors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (mentorIdToUpdate == 0)
            {
                MessageBox.Show("Please select a mentor to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this mentor?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _mentorController.DeleteMentor(mentorIdToUpdate);
                MessageBox.Show("Mentor deleted successfully!");
                ClearForm();
                LoadMentors();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearForm()
        {
            mentorIdToUpdate = 0;
            txtName.Text = "";
            txtNIC.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            cmbDepartment.SelectedIndex = -1;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNIC.Text)) { MessageBox.Show("NIC is required."); return false; }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new MailAddress(txtEmail.Text.Trim());
                    if (addr.Address != txtEmail.Text.Trim()) throw new FormatException();
                }
                catch
                {
                    MessageBox.Show("Invalid email address.");
                    return false;
                }
            }
            if (cmbDepartment.SelectedValue == null) { MessageBox.Show("Please select a Department."); return false; }
            return true;
        }
    }
}

