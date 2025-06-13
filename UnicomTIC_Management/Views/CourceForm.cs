using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;

namespace UnicomTIC_Management.Views
{
    public partial class CourceForm : Form
    {
        private readonly CourseController _controller;    
        private int _id = -1;
        public CourceForm()
        {
            _controller = new CourseController(new CourseService(new CourseRepository()));
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                var courses = _controller.GetAllCourses();
                _dataGridView.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void courcename_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Create CourseDTO from text box inputs
                var courseDTO = new CourseDTO
                {
                    CourseName = this.Controls.Find("courcename", true)[0].Text,
                    Description = this.Controls.Find("coursedescription", true)[0].Text
                };

                // Call controller to add course
                _controller.AddCourse(courseDTO);

                // Refresh DataGridView
                LoadCourses();

                // Clear form fields
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cource_main_SelectionChanged(object sender, EventArgs e)
        {
            if (_dataGridView.SelectedRows.Count > 0)
            {
                var courseDTO = _dataGridView.SelectedRows[0].DataBoundItem as CourseDTO;
                if (courseDTO != null)
                {
                    _id = courseDTO.CourseID;
                    //this.Controls.Find("txtCourseId", true)[0].Text = courseDTO.CourseID.ToString();
                    this.Controls.Find("courcename", true)[0].Text = courseDTO.CourseName;
                    this.Controls.Find("coursedescription", true)[0].Text = courseDTO.Description;
                }
            }
        }
        private void ClearFields()
        {
            _id = -1;
            //this.Controls.Find("txtCourseId", true)[0].Text = "";
            this.Controls.Find("courcename", true)[0].Text = "";
            this.Controls.Find("coursedescription", true)[0].Text = "";

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    MessageBox.Show("Please select a course to update.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var courseDTO = new CourseDTO
                {
                    CourseID = _id,
                    CourseName = this.Controls.Find("courcename", true)[0].Text,
                    Description = this.Controls.Find("coursedescription", true)[0].Text
                };

                _controller.UpdateCourse(courseDTO);
                LoadCourses();
                ClearFields();

                //MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {            

            try
            {
                if (_id == -1)
                {
                    MessageBox.Show("Please select a course to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _controller.DeleteCourse(_id);
                    LoadCourses();
                    ClearFields();

                    //MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CourceForm_Load(object sender, EventArgs e)
        {

        }
    }
}