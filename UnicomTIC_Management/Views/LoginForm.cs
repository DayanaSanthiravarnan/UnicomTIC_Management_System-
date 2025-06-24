using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Repositories;

namespace UnicomTIC_Management.Views
{
    internal partial class LoginForm : Form
    {

        private readonly UserController _userController = new UserController(new UserService(new UserRepository()));
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();


            if (username == "Dayana" && password == "1234")
                
            {
                new AdminViewForm();

                MessageBox.Show(username + MessageBoxButtons.OK);
                this.Hide();
                
            }
            User user = _userController.Login(username, password);

            if (user != null)
            {
                MessageBox.Show(username + MessageBoxButtons.OK);
                this.Hide();

                switch (user.Role)
                {

                  
                    case UserRole.Student:
                        new StudentViewForm(user.UserID).Show();
                        break;
                   case UserRole.Lecturer:
                        new LecturerViewForm(user.UserID).Show();
                        break;
                    case UserRole.Staff:
                        new StaffViewForm(user.UserID).Show();
                        break;
                   case UserRole.Mentor:
                        new MentorViewForm(user.UserID).Show();
                        break;
                    default:
                        MessageBox.Show("Unknown role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }


            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RoleRegistationForm().Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
