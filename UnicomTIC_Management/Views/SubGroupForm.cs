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
    public partial class SubGroupForm : Form
    {
        private readonly SubGroupController _controller;
        private readonly MainGroupController _mainGroupController;
        public SubGroupForm()
        {
            InitializeComponent();
            var subRepo = new SubGroupRepository();
            var mainRepo = new MainGroupRepository();
            var subService = new SubGroupService(subRepo);
            var mainService = new MainGroupService(mainRepo);

            _controller = new SubGroupController(subService);
            _mainGroupController = new MainGroupController(mainService);

            LoadMainGroups();
            LoadSubGroups();
        }
        private void LoadMainGroups()
        {
            var mainGroups = _mainGroupController.GetAllMainGroup();

            comboMainGroup.DataSource = null;        // Reset பண்ணுங்க
            comboMainGroup.DisplayMember = "GroupCode";  // காட்சி பெயர்
            comboMainGroup.ValueMember = "MainGroupID";      // பின்னணியில் இருக்கும் ID
            comboMainGroup.DataSource = mainGroups;
        }

        private void LoadSubGroups()
        {
            {
                var subGroups = _controller.GetAllSubGroups();
                var mainGroups = _mainGroupController.GetAllMainGroup();

                // MainGroupID to MainGroupName lookup dictionary
                var mainGroupDict = mainGroups.ToDictionary(mg => mg.MainGroupID, mg => mg.GroupCode);

                // Create anonymous object list with MainGroupName
                var subGroupViewList = subGroups.Select(sg => new
                {
                    sg.SubGroupID,
                    sg.SubGroupName,
                    sg.Description,
                    sg.MainGroupID,
                    MainGroupName = mainGroupDict.ContainsKey(sg.MainGroupID) ? mainGroupDict[sg.MainGroupID] : "N/A"
                }).ToList();

                dgvSubGroups.DataSource = subGroupViewList;

                // Optional: Hide MainGroupID column if you want
                if (dgvSubGroups.Columns["MainGroupID"] != null)
                    dgvSubGroups.Columns["MainGroupID"].Visible = false;
            }

        }

        private void SubGroupForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dto = new SubGroupDTO
            {
                MainGroupID = (int)comboMainGroup.SelectedValue,
                SubGroupName = txtSubGroupName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            _controller.AddSubGroup(dto);
            LoadSubGroups();
            ClearForm();
        }

        private void ClearForm()
        {
            txtSubGroupName.Text = "";
            txtDescription.Text = "";
            comboMainGroup.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubGroups.CurrentRow != null)
            {
                int id = (int)dgvSubGroups.CurrentRow.Cells["SubGroupID"].Value;
                _controller.DeleteSubGroup(id);
                LoadSubGroups();
            }
        }

        private void dgvSubGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubGroups.CurrentRow != null)
            {
                txtSubGroupName.Text = dgvSubGroups.CurrentRow.Cells["SubGroupName"].Value.ToString();
                txtDescription.Text = dgvSubGroups.CurrentRow.Cells["Description"].Value?.ToString();

                int mainGroupId = (int)dgvSubGroups.CurrentRow.Cells["MainGroupID"].Value;
                comboMainGroup.SelectedValue = mainGroupId;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSubGroups.CurrentRow != null)
            {
                var dto = new SubGroupDTO
                {
                    SubGroupID = (int)dgvSubGroups.CurrentRow.Cells["SubGroupID"].Value,
                    MainGroupID = (int)comboMainGroup.SelectedValue,
                    SubGroupName = txtSubGroupName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                _controller.UpdateSubGroup(dto);
                LoadSubGroups();
                ClearForm();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
