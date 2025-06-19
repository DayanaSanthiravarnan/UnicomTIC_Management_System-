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

namespace UnicomTIC_Management.Views
{
    public partial class StudentRegiForm : Form
    {
        private readonly UserController _userController;
        private readonly StudentController _studentController;
        private CourseController _courseController;

        public StudentRegiForm()
        {
            InitializeComponent();
            IUserRepository userRepository = new UserRepository();
            IUserService userService = new UserService(userRepository);
            _userController = new UserController(userService);

            IStudentRepository studentRepository = new StudentRepository();
            IStudentService studentService = new StudentService(studentRepository);
            _studentController = new StudentController(studentService);

            ICourseRepository courseRepository = new CourseRepository();
            ICourseService courseService = new CourseService(courseRepository);
            _courseController = new CourseController(courseService);

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StudentRegiForm_Load(object sender, EventArgs e)
        {
            cmbRole.DataSource = new string[] { "Student" };
            cmbRole.Enabled = false;

            cmbGender.Items.AddRange(new string[] { "Male", "Female" });

            var courses = _courseController.GetAllCourses();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";

            dtpEnrollmentDate.Value = DateTime.Now;
            dtpEnrollmentDate.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter username and password.");
                    return;
                }

                var user = new UserDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = UserRole.Student,
                    Status = UserStatus.Pending,   
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var student = new StudentDTO
                {
                    Name = txtName.Text.Trim(),
                    NIC = txtNIC.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    ContactNo = txtContactNo.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DateOfBirth = dtpDob.Value,
                    Gender = cmbGender.SelectedItem?.ToString(),
                    CourseID = (int)cmbCourse.SelectedValue,
                    EnrollmentDate = DateTime.Now,
                    Status = StudentStatus.Pending,  
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Pass data to UserManagementForm for admin approval
                var userManagementForm = new UserManagementForm(user, student);
                userManagementForm.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving student: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
