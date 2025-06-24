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
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Views
{
 
    public partial class SubjectForm : Form
    {
        private readonly SubjectController _subjectController;
        private readonly CourseController _courseController;
        private int _selectedSubjectId = -1;
        public SubjectForm()
        {
            InitializeComponent();  
            _courseController = new CourseController(new CourseService(new CourseRepository()));
            _subjectController = new SubjectController(new SubjectService(new SubjectRepository()));

            LoadCoursesIntoComboBox();
            LoadSubjectsIntoGrid();
        }

        private void LoadCoursesIntoComboBox()
        {
            try
            {
                var courses = _courseController.GetAllCourses();

                comboBoxCourses.DataSource = courses;
                comboBoxCourses.DisplayMember = "CourseName";
                comboBoxCourses.ValueMember = "CourseID";

                comboBoxCourses.SelectedIndex = -1; // No selection initially
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjectsIntoGrid()
        {
              try
    {
        var subjects = _subjectController.GetAllSubjects();
        subjectdgv.DataSource = subjects;

        subjectdgv.Columns["CourseID"].Visible = false;

        subjectdgv.Columns["SubjectID"].HeaderText = "ID";
        subjectdgv.Columns["SubjectName"].HeaderText = "Subject Name";
        subjectdgv.Columns["CourseName"].HeaderText = "Course";

        subjectdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        subjectdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        subjectdgv.MultiSelect = false;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading subjects: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }
        private void ClearForm()
        {
            _selectedSubjectId = -1;
            txtSubjectName.Text = "";
            comboBoxCourses.SelectedIndex = -1;
        }



        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
                {
                    MessageBox.Show("Please enter subject name.");
                    return;
                }

                if (comboBoxCourses.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a course.");
                    return;
                }

                // DTO, Save, Reload
                var subjectDTO = new SubjectDTO
                {
                    SubjectName = txtSubjectName.Text.Trim(),
                    CourseID = (int)comboBoxCourses.SelectedValue
                };

                _subjectController.AddSubject(subjectDTO);
                LoadSubjectsIntoGrid();
                ClearForm();

                MessageBox.Show("Subject added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subject: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {

            try
            {
                if (_selectedSubjectId == -1)
                {
                    MessageBox.Show("Please select a subject to update.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
                {
                    MessageBox.Show("Please enter subject name.");
                    return;
                }

                if (comboBoxCourses.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a course.");
                    return;
                }

                var subjectDTO = new SubjectDTO
                {
                    SubjectID = _selectedSubjectId,
                    SubjectName = txtSubjectName.Text.Trim(),
                    CourseID = (int)comboBoxCourses.SelectedValue
                };

                _subjectController.UpdateSubject(subjectDTO);
                LoadSubjectsIntoGrid();
                ClearForm();

                MessageBox.Show("Subject updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating subject: {ex.Message}");
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedSubjectId == -1)
                {
                    MessageBox.Show("Please select a subject to delete.");
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _subjectController.DeleteSubject(_selectedSubjectId);
                    LoadSubjectsIntoGrid();
                    ClearForm();

                    MessageBox.Show("Subject deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting subject: {ex.Message}");
            }

        }

        private void subjectdgv_SelectionChanged(object sender, EventArgs e)
        {
            if (subjectdgv.SelectedRows.Count > 0)
            {
                var subjectDTO = subjectdgv.SelectedRows[0].DataBoundItem as SubjectDTO;
                if (subjectDTO != null)
                {
                    _selectedSubjectId = subjectDTO.SubjectID;
                    txtSubjectName.Text = subjectDTO.SubjectName;

                    // Set the course combo box to correct course
                    comboBoxCourses.SelectedValue = subjectDTO.CourseID;
                }
            }
        }

        private void comboBoxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
