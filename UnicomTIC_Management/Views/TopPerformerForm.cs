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
    internal partial class TopPerformerForm : Form
    {

        private readonly SubjectController _subjectController;
        private readonly ExamController _examController;
        private readonly MarksController _marksController;
        private readonly TopPerformerController _topPerformerController;

        private List<MarksDTO> _topMarks;
        public TopPerformerForm()
        {
            InitializeComponent();

            _subjectController = new SubjectController(new SubjectService(new SubjectRepository()));
            var subjectService = new SubjectService(new SubjectRepository());
            _subjectController = new SubjectController(subjectService);
            _examController = new ExamController(new ExamService(new ExamRepository(), subjectService));
            _marksController = new MarksController(new MarksService(new MarksRepository()));
            _topPerformerController = new TopPerformerController(new TopPerformerService(new TopPerformerRepository()));

            LoadSubjects();
        }
        private void LoadSubjects()
        {
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.DataSource = _subjectController.GetAllSubjects();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TopPerformerForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvTopPerformers_SelectionChanged(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedValue is int subjectId)
            {
                cmbExam.DisplayMember = "ExamName";
                cmbExam.ValueMember = "ExamID";
                cmbExam.DataSource = _examController.GetAllExams()
                    .Where(exam => exam.SubjectID == subjectId)
                    .ToList();
            }
        }

        private void btnLoadTopPerformers_Click(object sender, EventArgs e)
        {
            if (cmbExam.SelectedValue is int examId)
            {
                _topMarks = _marksController.GetAllMarks()
                    .Where(m => m.ExamID == examId)
                    .OrderByDescending(m => m.MarksObtained)
                    .Take(5) // Optional: Top 5
                    .ToList();

                dgvTopPerformers.DataSource = _topMarks;
            }
        }

        private void btnSaveToTopPerformers_Click(object sender, EventArgs e)
        {
            if (_topMarks == null || !_topMarks.Any())
            {
                MessageBox.Show("Please load top performers first.");
                return;
            }

            foreach (var mark in _topMarks)
            {
                var tp = new TopPerformerDTO
                {
                    StudentID = mark.StudentID,
                    ExamID = mark.ExamID,
                    MarksObtained = mark.MarksObtained,
                    Grade = mark.Grade,
                    RecordedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                };
                _topPerformerController.AddTopPerformer(tp);
            }

            MessageBox.Show("Top performers saved successfully.");
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedValue == null) return;

            if (int.TryParse(cmbSubject.SelectedValue.ToString(), out int subjectId))
            {
                var exams = _examController.GetAllExams();
                var filteredExams = exams.Where(exam => exam.SubjectID == subjectId).ToList();

                cmbExam.DataSource = null; // clear before assigning new source
                cmbExam.DisplayMember = "ExamName";
                cmbExam.ValueMember = "ExamID";
                cmbExam.DataSource = filteredExams;
            }
            else
            {
                MessageBox.Show($"SelectedValue is not valid: {cmbSubject.SelectedValue}");
            }
        }
    }
    }

