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
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Views
{
    internal partial class StudentDetailsForm : Form
    {

        private readonly CourseController _courseController;
        private readonly MainGroupController _mainGroupController;
        private readonly SubGroupController _subGroupController;
        private readonly StudentController _studentController;

        private int selectedStudentId = 0;
        private int currentUserId = 0;

        private List<Course> courses = new List<Course>();
        private List<MainGroup> mainGroups = new List<MainGroup>();
        private List<SubGroup> subGroups = new List<SubGroup>();
        private List<StudentDTO> students = new List<StudentDTO>();


        public StudentDetailsForm(StudentController studentController, CourseController courseController, MainGroupController mainGroupController, SubGroupController subGroupController)
        {
            InitializeComponent();
            _studentController = studentController;
            _courseController = courseController;
            _mainGroupController = mainGroupController;
            _subGroupController = subGroupController;
            SetupEvents();
            LoadCourses();
            LoadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            var studentDTO = new StudentDTO
            {
                Name = txtName.Text.Trim(),
                NIC = xtNIC.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNo = txtContactNo.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Gender = cmbGender.SelectedItem?.ToString(),
                DateOfBirth = dtpDOB.Value,
                CourseID = (int)cmbCourse.SelectedValue,
                MainGroupID = (int)cmbMainGroup.SelectedValue,
                SubGroupID = (int)cmbSubGroup.SelectedValue,
                UserID = currentUserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _studentController.AddStudent(studentDTO);
            LoadStudents();
            ClearForm();
        }
        private void SetupEvents()
        {
            cmbCourse.SelectedIndexChanged += cmbCourse_SelectedIndexChanged;
            cmbMainGroup.SelectedIndexChanged += cmbMainGroup_SelectedIndexChanged;
            dgvStudents.CellClick += dgvStudents_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
        }


        private void StudentDetailsForm_Load(object sender, EventArgs e)
        {



            LoadComboBoxes();

        }
        private void LoadCourses()
        {
            var courseDTOs = _courseController.GetAllCourses();
            courses = courseDTOs.Select(dto => new Course { CourseID = dto.CourseID, CourseName = dto.CourseName }).ToList();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = -1;
        }

        private void LoadMainGroups(int courseId)
        {
            var mainGroupDTOs = _mainGroupController.GetAllMainGroup();
            mainGroups = mainGroupDTOs.Select(dto => new MainGroup { MainGroupID = dto.MainGroupID, GroupCode = dto.GroupCode }).ToList();
            cmbMainGroup.DataSource = mainGroups;
            cmbMainGroup.DisplayMember = "GroupCode";
            cmbMainGroup.ValueMember = "MainGroupID";
            cmbMainGroup.SelectedIndex = -1;
        }
        private void LoadSubGroupsFromDatabase(int? mainGroupId)
        {
            var subGroupDTOs = _subGroupController.GetAllSubGroups();
            subGroups = subGroupDTOs.Where(sg => sg.MainGroupID == mainGroupId).Select(dto => new SubGroup
            {
                SubGroupID = dto.SubGroupID,
                SubGroupName = dto.SubGroupName,
                MainGroupID = dto.MainGroupID
            }).ToList();
            cmbSubGroup.DataSource = subGroups;
            cmbSubGroup.DisplayMember = "SubGroupName";
            cmbSubGroup.ValueMember = "SubGroupID";
            cmbSubGroup.SelectedIndex = -1;
        }






        private void LoadComboBoxes()
        {
           

            

           
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;

            
        }

        

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedValue is int courseId)
            {
                LoadMainGroups(courseId);
            }
            else
            {
                cmbMainGroup.DataSource = null;
            }
        }

        private void cmbMainGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMainGroup.SelectedValue is int mainGroupId)
            {
                LoadSubGroupsFromDatabase(mainGroupId);
            }
        }
        private void LoadStudents()
        {
            students = _studentController.GetAllStudents();
            dgvStudents.DataSource = students.Select(s => new
            {
                s.StudentID,
                s.Name,
                s.NIC,
                s.Address,
                s.ContactNo,
                s.Email,
                s.Gender,
                DOB = s.DateOfBirth?.ToShortDateString() ?? "",
                Course = courses.FirstOrDefault(c => c.CourseID == s.CourseID)?.CourseName,
                MainGroup = mainGroups.FirstOrDefault(mg => mg.MainGroupID == s.MainGroupID)?.GroupCode,
                SubGroup = subGroups.FirstOrDefault(sg => sg.SubGroupID == s.SubGroupID)?.SubGroupName
            }).ToList();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvStudents.Rows[e.RowIndex];
            selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            var student = students.FirstOrDefault(s => s.StudentID == selectedStudentId);
            if (student == null) return;
            txtName.Text = student.Name;
            xtNIC.Text = student.NIC;
            txtAddress.Text = student.Address;
            txtContactNo.Text = student.ContactNo;
            txtEmail.Text = student.Email;
            cmbGender.SelectedItem = student.Gender;
            dtpDOB.Value = student.DateOfBirth ?? DateTime.Now;
            cmbCourse.SelectedValue = student.CourseID;
            LoadMainGroups(student.CourseID);
            if (student.MainGroupID.HasValue)
            {
                cmbMainGroup.SelectedValue = student.MainGroupID.Value;
            }
            else
            {
                cmbMainGroup.SelectedIndex = -1; // Or set to a default value if needed
            }
            LoadSubGroupsFromDatabase(student.MainGroupID);
            if (student.SubGroupID.HasValue)
            {
                cmbSubGroup.SelectedValue = student.SubGroupID.Value;
            }
            else
            {
                cmbSubGroup.SelectedIndex = -1; // Clear selection if null
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0 || !ValidateForm())
                return;

            var studentDTO = new StudentDTO
            {
                StudentID = selectedStudentId,
                Name = txtName.Text.Trim(),
                NIC = xtNIC.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNo = txtContactNo.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Gender = cmbGender.SelectedItem?.ToString(),
                DateOfBirth = dtpDOB.Value.Date,
                CourseID = cmbCourse.SelectedValue is int courseId ? courseId : 0,
                MainGroupID = cmbMainGroup.SelectedValue is int mainGroupId ? mainGroupId : (int?)null,
                SubGroupID = cmbSubGroup.SelectedValue is int subGroupId ? subGroupId : (int?)null,
                UserID = currentUserId,
                UpdatedAt = DateTime.Now
            };
           
            _studentController.UpdateStudent(studentDTO);
            LoadStudents();
            ClearForm();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0) return;
            var confirm = MessageBox.Show("Are you sure to delete this student?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _studentController.DeleteStudent(selectedStudentId);
                LoadStudents();
                ClearForm();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(xtNIC.Text))
            {
                MessageBox.Show("NIC is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Valid Email is required.");
                return false;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select Gender.");
                return false;
            }

            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select Course.");
                return false;
            }

            

            if (cmbMainGroup.SelectedValue == null)
            {
                MessageBox.Show("Please select Main Group.");
                return false;
            }

            if (cmbSubGroup.SelectedValue == null)
            {
                MessageBox.Show("Please select Sub Group.");
               return false;
            }

            return true;

        }
        private void ClearForm()
        {
            selectedStudentId = 0;
            txtName.Clear();
            xtNIC.Clear();
            txtAddress.Clear();
            txtContactNo.Clear();
            txtEmail.Clear();
            cmbGender.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            cmbMainGroup.DataSource = null;
            cmbSubGroup.DataSource = null;
            dtpDOB.Value = DateTime.Now;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void xtNIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
