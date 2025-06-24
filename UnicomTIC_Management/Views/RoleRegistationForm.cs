using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTIC_Management.Views
{
    public partial class RoleRegistationForm : Form
    {
        public RoleRegistationForm()
        {
            InitializeComponent();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RoleSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void lblContinue_Click(object sender, EventArgs e)
        {
            
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void blContinue_Click(object sender, EventArgs e)
        {
            Form selectedForm = null;

            if (rbStudent.Checked)
            {
                selectedForm = new StudentRegiForm();
            }
            else if (rbLecturer.Checked)
            {
                selectedForm = new LecturerRegistrationForm();
            }
            else if (rbStaff.Checked)
            {
                selectedForm = new StaffRegiForm();
            }
            else if (rbMentor.Checked)
            {
                selectedForm = new MentorRegiForm();
            }

            if (selectedForm != null)
            {
              new LoginForm();
            }
            else
            {
                MessageBox.Show("Please select a role before continuing.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
