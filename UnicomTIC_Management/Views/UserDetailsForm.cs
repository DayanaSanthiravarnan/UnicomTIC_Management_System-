using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Views
{
    internal partial class UserDetailsForm : Form
    {

        private UserController _controller;
        private UserDTO _user;
        public UserDetailsForm(UserController controller, UserDTO user = null)
        {
            InitializeComponent();
            _controller = controller;
            _user = user;

            // Bind ComboBoxes with Enum values (not strings)
            cmbRole.DataSource = Enum.GetValues(typeof(UserRole));
            cmbStatus.DataSource = Enum.GetValues(typeof(UserStatus));

            if (_user != null)
            {
                LoadUserData();
            }
            else
            {
                // Set default Status as Pending for new users
                cmbStatus.SelectedItem = UserStatus.Pending;
            }
        }

        

        private void LoadUserData()
        {
            txtUsername.Text = _user.Username;
            txtPassword.Text = _user.Password;
            txtNIC.Text = _user.NIC;

            // Set SelectedItem as enum value
            cmbRole.SelectedItem = _user.Role;
            cmbStatus.SelectedItem = _user.Status;
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            LoadRoles();

            if (_user != null)
            {
                LoadUserData();
            }
        }
        private void LoadRoles()
        {
            cmbRole.DataSource = Enum.GetNames(typeof(UserRole));
            cmbStatus.DataSource = Enum.GetNames(typeof(UserStatus));
        }

        
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new UserDTO
                {
                    UserID = _user?.UserID ?? 0,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    NIC = txtNIC.Text,
                    Role = (UserRole)cmbRole.SelectedItem,
                    Status = (UserStatus)cmbStatus.SelectedItem,
                    CreatedAt = _user?.CreatedAt ?? DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                if (_user == null || newUser.UserID == 0)
                {
                    _controller.CreateUser(newUser);
                    MessageBox.Show("User created successfully!");
                }
                else
                {
                    _controller.UpdateUser(newUser);
                    MessageBox.Show("User updated successfully!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed: " + ex.Message);
            }


        }


   


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
