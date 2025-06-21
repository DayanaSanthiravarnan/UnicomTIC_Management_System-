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

namespace UnicomTIC_Management.Views
{
    public partial class StaffRegiForm : Form
    {
        private readonly UserController _userController;
        private readonly StaffController _staffController;
     
        private readonly NICDetailController _nicController;
        public StaffRegiForm()
        {
            InitializeComponent();

            var userRepo = new UserRepository();
            var userService = new UserService(userRepo);
            _userController = new UserController(userService);

            var staffRepo = new StaffRepository();
            var staffService = new StaffService(staffRepo);
            _staffController = new StaffController(staffService);

           

            var nicRepo = new NICDetailRepository();
            var nicService = new NICDetailService(nicRepo);
            _nicController = new NICDetailController(nicService);
        }

        private void StaffRegiForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and Password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNIC.Text))
            {
                MessageBox.Show("NIC is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string contact = txtContactNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(contact) || !contact.All(char.IsDigit) || contact.Length != 10)
            {
                MessageBox.Show("Contact Number must be exactly 10 digits and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    if (addr.Address != email)
                    {
                        MessageBox.Show("Invalid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid email address format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var nicInput = txtNIC.Text.Trim();
            var nicDTO = _nicController.GetByNIC(nicInput);
            if (nicDTO == null)
            {
                MessageBox.Show("NIC not found in NICDetails table. Please register NIC first.", "NIC Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_nicController.IsNICUsed(nicInput))
            {
                MessageBox.Show("This NIC is already used for registration.", "NIC Already Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



try
                {
                    var userDTO = new UserDTO
                    {
                        Username = txtUsername.Text.Trim(),
                        Password = txtPassword.Text,
                        NIC = nicInput,
                        Role = UserRole.Staff,
                        Status = UserStatus.Pending
                    };

                    int userId = _userController.CreateUser(userDTO);

                    if (userId <= 0)
                    {
                        MessageBox.Show("User creation failed. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var staffDTO = new StaffDTO
                    {
                        Name = txtName.Text.Trim(),
                        NIC = nicInput,
                        Email = txtEmail.Text.Trim(),
                        ContactNo = contact,
                        UserID = userId
                    };

                    int staffId = _staffController.AddStaff(staffDTO);

                    if (staffId > 0)
                    {
                        _nicController.MarkAsUsed(nicInput);
                        MessageBox.Show("Staff registration successful! Awaiting admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register staff. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                    if (ex.InnerException != null)
                        errorMessage += "\nInner Exception: " + ex.InnerException.Message;

                    MessageBox.Show("Error during registration: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
