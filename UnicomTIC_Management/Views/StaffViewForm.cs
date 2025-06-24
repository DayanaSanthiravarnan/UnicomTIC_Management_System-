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
    public partial class StaffViewForm : Form
    {
        private readonly int _userId;
        private readonly StaffController _staffController;
        public StaffViewForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _staffController = new StaffController(new StaffService(new StaffRepository()));
            Load += StaffViewForm_Load;
        }

        private void StaffViewForm_Load(object sender, EventArgs e)
        {
            LoadStaffDetails();
        }
        private void LoadStaffDetails()
        {
            StaffDTO staff = _staffController.GetStaffByUserId(_userId);
            if (staff == null)
            {
                MessageBox.Show("Staff details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblName.Text = $"Name: {staff.Name}";
            lblNIC.Text = $"NIC: {staff.NIC}";
            lblEmail.Text = $"Email: {staff.Email}";
            lblContactNo.Text = $"Contact: {staff.ContactNo}";
            lblDepartmentID.Text = $"Department: {(staff.DepartmentName ?? "N/A")}";
           
        }
    }
}
