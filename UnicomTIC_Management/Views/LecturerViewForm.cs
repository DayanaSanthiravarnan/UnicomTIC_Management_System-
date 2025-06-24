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
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;

namespace UnicomTIC_Management.Views
{
    public partial class LecturerViewForm : Form
    {
        private readonly int _userId;
        private readonly LecturerController _lecturerController;

        public LecturerViewForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _lecturerController = new LecturerController(new LecturerService(new LecturerRepository()));

            this.Load += LecturerViewForm_Load;
        }

        private void LecturerViewForm_Load(object sender, EventArgs e)
        {
            LoadLecturerDetails();
        }
        private void LoadLecturerDetails()
        {
            LecturerDTO lecturer = _lecturerController.GetLecturerByUserId(_userId);
            if (lecturer == null)
            {
                MessageBox.Show("Lecturer details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Display all lecturer fields
            
            lblName.Text = $"Name: {lecturer.Name}";
            lblNIC.Text = $"NIC: {lecturer.NIC}";
            lblPhone.Text = $"Phone: {lecturer.Phone}";
            lblAddress.Text = $"Address: {lecturer.Address}";
            lblEmail.Text = $"Email: {lecturer.Email}";
           
            lblDepartmentName.Text = $"Department: {lecturer.DepartmentName ?? "N/A"}";
           
           
          
        }
    }
}
