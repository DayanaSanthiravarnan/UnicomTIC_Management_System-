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
    public partial class StudentViewForm : Form
    {
        private readonly int _userId;
        private readonly StudentController _studentController;
        private readonly TimetableController _timetableController;

        public StudentViewForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            
            _studentController = new StudentController(new StudentService(new StudentRepository()));
            _timetableController = new TimetableController(new TimetableService(new TimetableRepository()));

            this.Load += StudentViewForm_Load;
        }

        private void StudentViewForm_Load(object sender, EventArgs e)
        {
            LoadStudentDetails();
            LoadTimetable();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadStudentDetails()
        {
            StudentDTO student = _studentController.GetStudentByUserId(_userId);
            if (student == null)
            {
                MessageBox.Show("Student details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Display student info with names (make sure DTO has these properties)
            lblName.Text = $"Name: {student.Name}";
            lblEmail.Text = $"Email: {student.Email}";
            lblNIC.Text = $"NIC: {student.NIC}";
            lblContact.Text = $"Contact: {student.ContactNo}";
            lblCourseID.Text = $"Course: {student.CourseName ?? "N/A"}";
            lblMainGroupID.Text = $"Main Group: {student.MainGroupName ?? "N/A"}";
            lblSubGroupID.Text = $"Sub Group: {student.SubGroupName ?? "N/A"}";
        }

      private void LoadTimetable()
{
            StudentDTO student = _studentController.GetStudentByUserId(_userId);
            if (student == null)
                return;

            List<TimetableDTO> timetableList = _timetableController.GetTimetableViewByGroup(
                student.MainGroupID ?? 0,
                student.SubGroupID);

            dgvTimetable.DataSource = timetableList;

            // Optional: Set friendly column headers
            dgvTimetable.Columns["CourseName"].HeaderText = "Course";
            dgvTimetable.Columns["LecturerName"].HeaderText = "Lecturer";
            dgvTimetable.Columns["RoomName"].HeaderText = "Room";
            dgvTimetable.Columns["DayOfWeek"].HeaderText = "DayOfWeek";
            dgvTimetable.Columns["StartTime"].HeaderText = "Start Time";
            dgvTimetable.Columns["EndTime"].HeaderText = "End Time";
            dgvTimetable.Columns["MainGroupName"].HeaderText = "Main Group";
            dgvTimetable.Columns["SubGroupName"].HeaderText = "Sub Group";
        }
    }
}
