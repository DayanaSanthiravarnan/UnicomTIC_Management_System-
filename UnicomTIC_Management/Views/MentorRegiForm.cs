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
    public partial class MentorRegiForm : Form
    {
        private readonly UserController _userController;
        private readonly MentorController _mentorController;
        private readonly NICDetailController _nicController;
        public MentorRegiForm()
        {
            InitializeComponent();

            var userRepo = new UserRepository();
            var userService = new UserService(userRepo);
            _userController = new UserController(userService);

            var mentorRepo = new MentorRepository();
            var mentorService = new MentorService(mentorRepo);
            _mentorController = new MentorController(mentorService);

            var nicRepo = new NICDetailRepository();
            var nicService = new NICDetailService(nicRepo);
            _nicController = new NICDetailController(nicService);
        }

        private void MentorRegiForm_Load(object sender, EventArgs e)
        {
            cmbGender.Items.AddRange(new string[] { "Male", "Female" });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and Password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userController.IsUsernameTaken(txtUsername.Text.Trim()))
            {
                MessageBox.Show("invalid username. Please choose another.", "Username Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = txtPassword.Text.Trim();
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                MessageBox.Show("Password must include at least one special character (e.g. !, @, #, etc.).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Contact Number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string nic = txtNIC.Text.Trim();
            var nicDTO = _nicController.GetByNIC(nic);
            if (nicDTO == null)
            {
                MessageBox.Show("NIC not found in NICDetails table.", "NIC Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_nicController.IsNICUsed(nic))
            {
                MessageBox.Show("This NIC is already used.", "NIC In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var userDTO = new UserDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    NIC = nic,
                    Role = UserRole.Mentor,
                    Status = UserStatus.Pending
                };

                int userId = _userController.CreateUser(userDTO);

                var mentorDTO = new MentorDTO
                {
                    Name = txtName.Text.Trim(),
                    NIC = nic,
                    Email = email,
                    Phone = contact,
                    UserID = userId,

                };

                int mentorId = _mentorController.AddMentor(mentorDTO);

                if (mentorId > 0)
                {
                    _nicController.MarkAsUsed(nic);
                    MessageBox.Show("Mentor registered successfully. Awaiting approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to register mentor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


            


    

