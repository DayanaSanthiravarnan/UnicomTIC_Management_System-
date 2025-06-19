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
    public partial class ExamForm : Form
    {
        private readonly ExamController _examCtrl;
        private readonly CourseController _courseCtrl;
        private readonly SubjectController _subjectCtrl;
        private int _selectedExamId = -1;

        public ExamForm()
        {
            InitializeComponent();

            var examRepo = new ExamRepository();
            var subjectRepo = new SubjectRepository();
            var subjectService = new SubjectService(subjectRepo);

            _examCtrl = new ExamController(new ExamService(examRepo, subjectService));
            _courseCtrl = new CourseController(new CourseService(new CourseRepository()));
            _subjectCtrl = new SubjectController(subjectService);

            LoadCourses();
            LoadExamTypes();
            LoadExamGrid();

            comboCourse.SelectedIndexChanged += comboCourse_SelectedIndexChanged;
            examsView.SelectionChanged += examsView_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
        }

        private void LoadCourses()
        {
            var courses = _courseCtrl.GetAllCourses();
            comboCourse.DataSource = courses;
            comboCourse.DisplayMember = "CourseName";
            comboCourse.ValueMember = "CourseID";
            comboCourse.SelectedIndex = -1;
        }

        private void LoadSubjectsByCourse(int courseId)
        {
            var subjects = _subjectCtrl.GetSubjectsByCourseId(courseId);
            mbSubject.DataSource = subjects;
            mbSubject.DisplayMember = "SubjectName";
            mbSubject.ValueMember = "SubjectID";
            mbSubject.SelectedIndex = -1;
        }

        private void LoadExamTypes()
        {
            cmbExamType.Items.Clear();
            cmbExamType.Items.AddRange(new string[] { "Written", "Online", "Practical" });
            cmbExamType.SelectedIndex = -1;
        }

        private void LoadExamGrid()
        {
            examsView.DataSource = _examCtrl.GetAllExams();
            examsView.ClearSelection();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var dto = new ExamDTO
            {
                ExamName = txtExamName.Text.Trim(),
                SubjectID = Convert.ToInt32(mbSubject.SelectedValue),
                ExamDate = dgvExams.Value.ToString("yyyy-MM-dd"),
                ExamType = cmbExamType.Text,
                MaxMarks = int.Parse(txtMaxMarks.Text)
            };

            _examCtrl.AddExam(dto);
            LoadExamGrid();
            ClearForm();
        }

        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboCourse.SelectedValue is int courseId)
                LoadSubjectsByCourse(courseId);
            else
                mbSubject.DataSource = null;
        }

        private void examsView_SelectionChanged(object sender, EventArgs e)
        {
            if (examsView.CurrentRow?.DataBoundItem is ExamDTO dto)
            {
                _selectedExamId = dto.ExamID;
                txtExamName.Text = dto.ExamName;
                dgvExams.Value = DateTime.Parse(dto.ExamDate);
                cmbExamType.Text = dto.ExamType;
                txtMaxMarks.Text = dto.MaxMarks.ToString();

                var subjects = _subjectCtrl.GetSubjectsByCourseId(dto.CourseID);
                mbSubject.DataSource = subjects;
                mbSubject.DisplayMember = "SubjectName";
                mbSubject.ValueMember = "SubjectID";
                mbSubject.SelectedValue = dto.SubjectID;

                comboCourse.SelectedValue = dto.CourseID;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (_selectedExamId <= 0)
            {
                MessageBox.Show("Please select an exam first.");
                return;
            }
            var dto = new ExamDTO
            {
                ExamID = _selectedExamId,
                ExamName = txtExamName.Text.Trim(),
                SubjectID = Convert.ToInt32(mbSubject.SelectedValue),
                ExamDate = dgvExams.Value.ToString("yyyy-MM-dd"),
                ExamType = cmbExamType.Text,
                MaxMarks = int.Parse(txtMaxMarks.Text)
            };

            _examCtrl.UpdateExam(dto);
            LoadExamGrid();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedExamId <= 0) return;
            _examCtrl.DeleteExam(_selectedExamId);
            LoadExamGrid();
            ClearForm();
        }
        private void ClearForm()
        {
            _selectedExamId = -1;
            txtExamName.Clear();
            txtMaxMarks.Clear();
            comboCourse.SelectedIndex = -1;
            mbSubject.DataSource = null;
            cmbExamType.SelectedIndex = -1;
            dgvExams.Value = DateTime.Today;
          
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvExams_ValueChanged(object sender, EventArgs e)
        {
           
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtExamName.Text))
            {
                MessageBox.Show("Exam Name is required.");
                return false;
            }
            if (comboCourse.SelectedIndex == -1 || mbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Course and Subject.");
                return false;
            }
            if (cmbExamType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Exam Type.");
                return false;
            }
            if (!int.TryParse(txtMaxMarks.Text, out _))
            {
                MessageBox.Show("Please enter a valid number for Max Marks.");
                return false;
            }

            return true;
        }

    }
}
