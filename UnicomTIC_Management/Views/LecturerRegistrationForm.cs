using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories.UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;

namespace UnicomTIC_Management.Views
{
    public partial class LecturerRegistrationForm : Form
    {
        private readonly UserController _userController;
        private readonly LecturerController _lecturerController;
        private readonly NICDetailController _nicController;
        private readonly DepartmentController _departmentController;


        public LecturerRegistrationForm()
        {
            InitializeComponent();

            var userService = new UserService(new UserRepository());
            _userController = new UserController(userService);

            var lecturerService = new LecturerService(new LecturerRepository());
            _lecturerController = new LecturerController(lecturerService);

            var nicService = new NICDetailService(new NICDetailRepository());
            _nicController = new NICDetailController(nicService);

          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LecturerRegistrationForm_Load(object sender, EventArgs e)
        { }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text.Trim().Length < 5)
            {
                MessageBox.Show("Address must be at least 5 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string contact = txtPhone.Text.Trim();
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
                    var addr = new MailAddress(email);
                    if (addr.Address != email)
                        throw new FormatException();
                }
                catch
                {
                    MessageBox.Show("Invalid email address format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string nicInput = txtNIC.Text.Trim();
            var nicDTO = _nicController.GetByNIC(nicInput);

            if (nicDTO == null)
            {
                MessageBox.Show("NIC not found in NICDetails. Please register NIC first.", "NIC Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_nicController.IsNICUsed(nicInput))
            {
                MessageBox.Show("This NIC is already used for registration.", "NIC Already Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 2. Create User
                var userDTO = new UserDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    NIC = nicInput,
                    Role = UserRole.Lecturer,
                    Status = UserStatus.Pending
                };
                int userId = _userController.CreateUser(userDTO);

                

                // 3. Create Lecturer
                var lecturerDTO = new LecturerDTO
                {
                    Name = txtName.Text.Trim(),
                    NIC = nicInput,
                    Address = txtAddress.Text.Trim(),
                    Email = email,
                    Phone = contact,
                    
                    
                    UserID = userId
                };

                int lecturerId = _lecturerController.AddLecturer(lecturerDTO);

                if (lecturerId > 0)
                {
                    _nicController.MarkAsUsed(nicInput);
                    MessageBox.Show("Lecturer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lecturer registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    

        private void ClearForm()
        {
           txtUsername.Text = "";
           txtPassword.Text = "";
          txtName.Text = "";
            txtNIC.Text = "";
           txtPhone.Text = "";
           txtAddress.Text = "";
           txtEmail.Text = "";
           
        }

    }
}
