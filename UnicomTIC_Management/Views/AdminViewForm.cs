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
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Views
{
    public partial class AdminViewForm : Form
    {
        private StudentController studentController;
        private CourseController courseController;
        private MainGroupController mainGroupController;
        private SubGroupController subGroupController;
        private MarksService marksService;
        public AdminViewForm()
        {
            InitializeComponent();
            HookUpButtonEvents();
            InitializeComponent();

            studentController = new StudentController(new StudentService(new StudentRepository()));
            courseController = new CourseController(new CourseService(new CourseRepository()));
            mainGroupController = new MainGroupController(new MainGroupService(new MainGroupRepository()));
            subGroupController = new SubGroupController(new SubGroupService(new SubGroupRepository()));
            marksService = new MarksService(new MarksRepository());

        }
        private void HookUpButtonEvents()
        {
            staff.Click += staff_Click;
            mentor.Click += mentor_Click;
            student.Click += student_Click;
            Lecturer.Click += Lecturer_Click;
            department.Click += department_Click;
            exam.Click += exam_Click;
            course.Click += course_Click;
            Maingroup.Click += Maingroup_Click;
            subject.Click += subject_Click;
            topperformer.Click += topperformer_Click;
            subgroup.Click += subgroup_Click;
            nic.Click += nic_Click;
            room.Click += room_Click;
            timetable.Click += timetable_Click;
            attendance.Click += attendance_Click;
        }
        private void LoadFormIntoMainPanel(Form form)
        {
            mainpanel.Controls.Clear();              
            form.TopLevel = false;                    
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;              
            mainpanel.Controls.Add(form);             
            form.ShowDialog();
        }


        private void Maingroup_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new MainGroupForm());
        }

        private void subgroup_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new SubGroupForm());
        }

        private void topperformer_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new TopPerformerForm());
        }

        private void timetable_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new TimetableForm());
        }

        private void course_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new CourceForm());
        }

        private void department_Click(object sender, EventArgs e)
        {

            LoadFormIntoMainPanel(new DepartmentForm());


        }

        private void exam_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new ExamForm());
        }

        private void Lecturer_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new LecturerDetailsForm());
        }

        private void student_Click(object sender, EventArgs e)
        {
            StudentDetailsForm form = new StudentDetailsForm(
                studentController,
                courseController,
                mainGroupController,
                subGroupController
            );
            LoadFormIntoMainPanel(form);  
        }

        private void mentor_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new MentorDetailForm());
        }

        private void staff_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new StaffDetailForm());
        }

        private void nic_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new NICRegistrationForm());
        }

        private void room_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new RoomManagementForm());
        }

        private void subject_Click(object sender, EventArgs e)
        {
            LoadFormIntoMainPanel(new SubjectForm());
        }

        private void AdminViewForm_Load(object sender, EventArgs e)
        {

        }

        private void attendance_Click(object sender, EventArgs e)
        {
            var attendanceRepository = new AttendanceRepository();
            var attendanceService = new AttendanceService(attendanceRepository);
            var attendanceController = new AttendanceController(attendanceService);
            var marksController = new MarksController(marksService);
            LoadFormIntoMainPanel((new AttendanceForm(attendanceController, studentController)));
        }
    }
    
}
