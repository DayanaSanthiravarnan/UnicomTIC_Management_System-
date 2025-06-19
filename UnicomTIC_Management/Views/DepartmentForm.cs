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

namespace UnicomTIC_Management.Views
{
    public partial class DepartmentForm : Form
    {
        private readonly DepartmentController _controller;
        private int _id = -1;

        public DepartmentForm()
        {
            _controller = new DepartmentController(new DepartmentService(new DepartmentRepository()));
            InitializeComponent();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = _controller.GetAllDepartments();
                this.Controls.Find("dgvDepartments", true)[0].DataBindings.Clear();
                var grid = this.Controls.Find("dgvDepartments", true)[0] as DataGridView;
                grid.DataSource = departments;
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var departmentDTO = new DepartmentDTO
                {
                    DepartmentName = this.Controls.Find("txtDepartmentName", true)[0].Text
                };

                _controller.AddDepartment(departmentDTO);
                LoadDepartments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    MessageBox.Show("Please select a department to update.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var departmentDTO = new DepartmentDTO
                {
                    DepartmentID = _id,
                    DepartmentName = this.Controls.Find("txtDepartmentName", true)[0].Text
                };

                _controller.UpdateDepartment(departmentDTO);
                LoadDepartments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (_id == -1)
                {
                    MessageBox.Show("Please select a department to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this department?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _controller.DeleteDepartment(_id);
                    LoadDepartments();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            var grid = this.Controls.Find("dgvDepartments", true)[0] as DataGridView;
            if (grid.SelectedRows.Count > 0)
            {
                var departmentDTO = grid.SelectedRows[0].DataBoundItem as DepartmentDTO;
                if (departmentDTO != null)
                {
                    _id = departmentDTO.DepartmentID;
                    this.Controls.Find("txtDepartmentName", true)[0].Text = departmentDTO.DepartmentName;
                }
            }
        }
        private void ClearFields()
        {
            _id = -1;
            this.Controls.Find("txtDepartmentName", true)[0].Text = "";
        }
    }
}
