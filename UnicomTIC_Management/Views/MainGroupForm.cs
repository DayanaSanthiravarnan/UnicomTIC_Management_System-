using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;

namespace UnicomTIC_Management.Views
{
    public partial class MainGroupForm : Form
    {
        private readonly MainGroupController _controller;
        private int _selectedId = -1;

        public MainGroupForm()
        {
            InitializeComponent();
            _controller = new MainGroupController(new MainGroupService(new MainGroupRepository()));
            LoadMainGroups();
        }

        private void LoadMainGroups()
        {
            try
            {
                var mainGroups = _controller.GetAllMainGroup();
                dataGridView1.DataSource = mainGroups;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading main groups: {ex.Message}");
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var mainGroupDTO = dataGridView1.SelectedRows[0].DataBoundItem as MainGroupDTO;
                    if (mainGroupDTO != null)
                    {
                        _selectedId = mainGroupDTO.MainGroupID;
                        groupcode.Text = mainGroupDTO.GroupCode;
                        description.Text = mainGroupDTO.Description;
                    }
                }
            }
        }
        private void ClearFields()
        {
            _selectedId = -1;
            groupcode.Clear();
            description.Clear();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                var mainGroupDTO = new MainGroupDTO
                {
                    GroupCode = groupcode.Text,
                    Description = description.Text
                    
                };

                _controller.AddMainGroup(mainGroupDTO);
                LoadMainGroups();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding main group: {ex.Message}");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

            if (_selectedId == -1)
            {
                MessageBox.Show("Please select a main group to update.");
                return;
            }

            try
            {
                var mainGroupDTO = new MainGroupDTO
                {
                    MainGroupID = _selectedId,
                    GroupCode = groupcode.Text,
                    Description = description.Text
                };

                _controller.UpdateMainGroup(mainGroupDTO);
                LoadMainGroups();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating main group: {ex.Message}");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedId == -1)
                {
                    MessageBox.Show("Please select a course to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _controller.DeleteMainGroup(_selectedId);
                    LoadMainGroups();
                    ClearFields();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void MainGroupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
    
