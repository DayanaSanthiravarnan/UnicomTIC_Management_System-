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
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Repositories.UnicomTIC_Management.Repositories;

namespace UnicomTIC_Management.Views
{
    public partial class StudentRegiForm : Form
    {
        private readonly UserController _userController;
        private readonly StudentController _studentController;
        private CourseController _courseController;
        private NICDetailController _nicController;

        public StudentRegiForm()
        {
            InitializeComponent();

            // Initialize Repositories and Services outside this snippet,
            // Here just sample initialization:
            var userRepo = new UserRepository();
            var userService = new UserService(userRepo);
            _userController = new UserController(userService);

            var studentRepo = new StudentRepository();
            var studentService = new StudentService(studentRepo);
            _studentController = new StudentController(studentService);

            var courseRepo = new CourseRepository();
            var courseService = new CourseService(courseRepo);
            _courseController = new CourseController(courseService);

            var nicRepo = new NICDetailRepository();
            var nicService = new NICDetailService(nicRepo);
            _nicController = new NICDetailController(nicService);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StudentRegiForm_Load(object sender, EventArgs e)
        {



            MessageBox.Show("Form Load Triggered!"); 

            cmbGender.Items.AddRange(new string[] { "Male", "Female" });

            var courses = _courseController.GetAllCourses();
            if (courses == null || !courses.Any())
            {
                MessageBox.Show("No courses found.");
                return;
            }

            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";

            dtpEnrollmentDate.Value = DateTime.Now;
            dtpEnrollmentDate.Enabled = false;

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

            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text.Trim().Length < 5)
            {
                MessageBox.Show("Address is required and must be at least 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string contact = txtContactNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(contact) || !contact.All(char.IsDigit) || contact.Length != 10)
            {
                MessageBox.Show("Contact Number must be exactly 10 digits and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Optional: Email validation
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
                // Step 1: Create User
                var userDTO = new UserDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    NIC = nicInput,
                    Role = UserRole.Student,
                    Status = UserStatus.Pending
                };
                int userId = _userController.CreateUser(userDTO);

                // Step 2: Create Student
                var studentDTO = new StudentDTO
                {
                    Name = txtName.Text.Trim(),
                    NIC = nicInput,
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    ContactNo = contact,
                    DateOfBirth = dtpDob.Value,
                    Gender = cmbGender.Text,
                    EnrollmentDate = dtpEnrollmentDate.Value,
                    CourseID = Convert.ToInt32(cmbCourse.SelectedValue),
                    UserID = userId
                };
                int studentId = _studentController.AddStudent(studentDTO);

                if (studentId > 0)
                {
                    _nicController.MarkAsUsed(nicInput);
                    MessageBox.Show("Registration successful! Awaiting admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to register student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
