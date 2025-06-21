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
    public partial class RoleSelectForm : Form
    {
        public RoleSelectForm()
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
            //if (rbstudent.checked)
            //{
            //    this.hide();
            //    new studentregistrationform().show();
            //}
            //else if (rblecturer.checked)
            //{
            //    this.hide();
            //    new lecturerregistrationform().show();
            //}
            //else if (rbstaff.checked)
            //{
            //    this.hide();
            //    new staffregistrationform().show();
            //}
            //else if (rbmentor.checked) // ✅ new role logic
            //{
            //    this.hide();
            //    new mentorregistrationform().show();
            //}
            //else
            //{
            //    messagebox.show("please select a role before continuing.", "required", messageboxbuttons.ok, messageboxicon.warning);
            //}
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
