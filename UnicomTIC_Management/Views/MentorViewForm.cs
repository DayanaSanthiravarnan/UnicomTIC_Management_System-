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
    public partial class MentorViewForm : Form
    {

        private readonly int _userId;
        private readonly MentorController _mentorController;

        public MentorViewForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _mentorController = new MentorController(new MentorService(new MentorRepository()));

            this.Load += MentorViewForm_Load;
        }
        private void MentorViewForm_Load(object sender, EventArgs e)
        {
            LoadMentorDetails();
        }
        private void LoadMentorDetails()
        {
            MentorDTO mentor = _mentorController.GetMentorByUserId(_userId);
            if (mentor == null)
            {
                MessageBox.Show("Mentor details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

           
            lblName.Text = $"Name: {mentor.Name}";
            lblNIC.Text = $"NIC: {mentor.NIC}";
            lblPhone.Text = $"Phone: {mentor.Phone}";
            lblEmail.Text = $"Email: {mentor.Email}";
            lblDepartment.Text = $"Department: {mentor.DepartmentName ?? "N/A"}";
            
        }
    }
}
