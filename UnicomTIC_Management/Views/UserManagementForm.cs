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
    public partial class UserManagementForm : Form
    {
        private readonly UserController _userController;
        private readonly StudentController _studentController;
        private readonly MainGroupController _mainGroupController;
        //private readonly SubGroupController _subGroupController;
        private readonly SubjectController _subjectController;

        private readonly UserDTO _pendingUser;
        private readonly StudentDTO _pendingStudent;

        // Constructor with parameters to inject controllers and pending user/student
        internal UserManagementForm(
            UserController userController,
            StudentController studentController,
            MainGroupController mainGroupController,
            //SubGroupController subGroupController,
            SubjectController subjectController,
            UserDTO user,
            StudentDTO student)
        {
            InitializeComponent();

            _userController = userController;
            _studentController = studentController;
            _mainGroupController = mainGroupController;
            //_subGroupController = subGroupController;
            _subjectController = subjectController;

            _pendingUser = user;
            _pendingStudent = student;
        }

            private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                _userController.ApproveUser(_pendingUser.UserID);

                if (_pendingUser.Role == UserRole.Student && _pendingStudent != null)
                {
                    _pendingStudent.Status = UserStatus.Approved;
                    _studentController.UpdateStudent(_pendingStudent);

                    var mainGroup = new MainGroupDTO
                    {
                       // StudentID = _pendingStudent.StudentID,
                       // GroupCode = "Default Main Group",
                       // CreatedAt = DateTime.Now,
                      //  UpdatedAt = DateTime.Now
                    };
                  //  int mainGroupId = _mainGroupController.CreateMainGroup(mainGroup);

                   // var subGroup = new SubGroupDTO
                    {
                        //MainGroupID = mainGroupId,
                        //SubGroupName = "Default Sub Group",
                        //CreatedAt = DateTime.Now,
                        //UpdatedAt = DateTime.Now
                    };
                    //int subGroupId = _subGroupController.CreateSubGroup(subGroup);

                   // var subject = new SubjectDTO
                    //{
                        //StudentID = _pendingStudent.StudentID,
                        //SubjectName = "Default Subject",
                        //CreatedAt = DateTime.Now,
                        //UpdatedAt = DateTime.Now
                    //};
                    //_subjectController.CreateSubject(subject);
                }

                MessageBox.Show("User approved and related data created.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            {
                lblUsername.Text = _pendingUser.Username;
                lblRole.Text = _pendingUser.Role.ToString();
                lblStatus.Text = _pendingUser.Status.ToString();

                if (_pendingUser.Role == UserRole.Student && _pendingStudent != null)
                {
                    pnlStudentInfo.Visible = true;
                    lblStudentName.Text = _pendingStudent.Name;
                    lblCourse.Text = GetCourseName(_pendingStudent.CourseID);
                    lblStudentStatus.Text = _pendingStudent.Status.ToString();
                }
                else
                {
                    pnlStudentInfo.Visible = false;
                }
            }
        }
        private string GetCourseName(int courseId)
        {
            // TODO: Replace with actual CourseController logic to get course name
            return "Sample Course";
        }


        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                _userController.RejectUser(_pendingUser.UserID);

                if (_pendingUser.Role == UserRole.Student && _pendingStudent != null)
                {
                    _pendingStudent.Status = UserStatus.Rejected;
                    _studentController.UpdateStudent(_pendingStudent);
                }

                MessageBox.Show("User rejected successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting user: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    


        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
           

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
          
        }
    }
}
