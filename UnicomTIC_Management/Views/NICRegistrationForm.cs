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
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Repositories.UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Services;

namespace UnicomTIC_Management.Views
{
    public partial class NICRegistrationForm : Form
    {
        private NICDetailController _nicController;


        public NICRegistrationForm()
        {
            InitializeComponent();

            // Setup repository, service, controller here (dependency chain)
            INICDetailRepository repo = new NICDetailRepository();
            INICDetailService service = new NICDetailService(repo);
            _nicController = new NICDetailController(service);

            LoadNICList();
        }

        private void LoadNICList()
        {
            var nicList = _nicController.GetAllNICs();
            dgvNICs.DataSource = nicList;
            dgvNICs.Columns["IsUsed"].HeaderText = "Is Used";
        }

        private void NICRegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nicText = txtNIC.Text.Trim();

            if (string.IsNullOrEmpty(nicText))
            {
                MessageBox.Show("Please enter NIC.");
                return;
            }

            var nicDTO = new NICDetailDTO
            {
                NIC = nicText,
                IsUsed = false
            };

            try
            {
                _nicController.AddNIC(nicDTO);
                MessageBox.Show("NIC saved successfully!");
                txtNIC.Clear();
                LoadNICList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving NIC: {ex.Message}");
            }
        }

        private void btnMarkUsed_Click(object sender, EventArgs e)
        {
            if (dgvNICs.CurrentRow == null)
            {
                MessageBox.Show("Select a NIC from the list.");
                return;
            }

            string selectedNIC = dgvNICs.CurrentRow.Cells["NIC"].Value.ToString();

            try
            {
                _nicController.MarkAsUsed(selectedNIC);
                MessageBox.Show("NIC marked as used.");
                LoadNICList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking NIC as used: {ex.Message}");
            }
        }
    }
}
