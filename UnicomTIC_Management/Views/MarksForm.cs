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

namespace UnicomTIC_Management.Views
{
    internal partial class MarksForm : Form
    {
        private readonly MarksController _marksController;
        private readonly StudentController _studentController;
        private readonly SubjectController _subjectController;
        private readonly ExamController _examController;

        public MarksForm(
         MarksController marksController,
         StudentController studentController,
         SubjectController subjectController,
         ExamController examController)
        {
            InitializeComponent();
            _marksController = marksController;
            _studentController = studentController;
            _subjectController = subjectController;
            _examController = examController;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void MarksForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadSubjects();
            LoadExams();
            LoadMarksGrid();
            ClearForm();
        }
        private void LoadStudents()
        {
            var students = _studentController.GetAllStudents();
            comboBoxStudent.DisplayMember = "Name";
            comboBoxStudent.ValueMember = "StudentID";
            comboBoxStudent.DataSource = students;
        }

        private void LoadSubjects()
        {
            var subjects = _subjectController.GetAllSubjects();
            comboBoxSubject.DisplayMember = "SubjectName";
            comboBoxSubject.ValueMember = "SubjectID";
            comboBoxSubject.DataSource = subjects;
        }

        private void LoadExams()
        {
            var exams = _examController.GetAllExams();
            comboBoxExam.DisplayMember = "ExamName";
            comboBoxExam.ValueMember = "ExamID";
            comboBoxExam.DataSource = exams;
        }

        private void LoadMarksGrid()
        {
            var marks = _marksController.GetAllMarks();
            dataGridViewMarks.DataSource = marks;

            // Optional: Customize columns for better display
            dataGridViewMarks.Columns["MarkID"].Visible = false;
            dataGridViewMarks.Columns["StudentID"].Visible = false;
            dataGridViewMarks.Columns["SubjectID"].Visible = false;
            dataGridViewMarks.Columns["ExamID"].Visible = false;

            dataGridViewMarks.Columns["StudentName"].HeaderText = "Student";
            dataGridViewMarks.Columns["SubjectName"].HeaderText = "Subject";
            dataGridViewMarks.Columns["ExamName"].HeaderText = "Exam";
            dataGridViewMarks.Columns["MarksObtained"].HeaderText = "Marks Obtained";
            dataGridViewMarks.Columns["Grade"].HeaderText = "Grade";
        }

        private void ClearForm()
        {
            comboBoxStudent.SelectedIndex = -1;
            comboBoxSubject.SelectedIndex = -1;
            comboBoxExam.SelectedIndex = -1;
            textBoxMarksObtained.Clear();
            textBoxGrade.Clear();
            hiddenMarkId.Text = ""; // hidden field for MarkID in update scenarios
            btnAdd.Text = "Add";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBoxMarksObtained.Text, out int marksObtained))
                {
                    MessageBox.Show("Please enter valid marks.");
                    return;
                }

                if (comboBoxStudent.SelectedIndex == -1 ||
                    comboBoxSubject.SelectedIndex == -1 ||
                    comboBoxExam.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select student, subject and exam.");
                    return;
                }

                var markDTO = new MarksDTO
                {
                    StudentID = (int)comboBoxStudent.SelectedValue,
                    SubjectID = (int)comboBoxSubject.SelectedValue,
                    ExamID = (int)comboBoxExam.SelectedValue,
                    MarksObtained = marksObtained,
                    Grade = textBoxGrade.Text.Trim()
                };

                if (string.IsNullOrEmpty(hiddenMarkId.Text))
                {
                    // Add new mark
                    _marksController.AddMark(markDTO);
                    MessageBox.Show("Mark added successfully!");
                }
                else
                {
                    // Update existing mark
                    markDTO.MarkID = int.Parse(hiddenMarkId.Text);
                    _marksController.UpdateMark(markDTO);
                    MessageBox.Show("Mark updated successfully!");
                    btnAdd.Text = "Add";
                }

                LoadMarksGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving mark: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarks.CurrentRow == null)
            {
                MessageBox.Show("Select a mark to delete.");
                return;
            }

            int markId = (int)dataGridViewMarks.CurrentRow.Cells["MarkID"].Value;

            var confirm = MessageBox.Show("Are you sure to delete this mark?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _marksController.DeleteMark(markId);
                    MessageBox.Show("Mark deleted successfully!");
                    LoadMarksGrid();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting mark: {ex.Message}");
                }
            }
        }

        private void dataGridViewMarks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMarks.CurrentRow == null)
                return;

            var mark = (MarksDTO)dataGridViewMarks.CurrentRow.DataBoundItem;
            if (mark == null)
                return;

            hiddenMarkId.Text = mark.MarkID.ToString();
            comboBoxStudent.SelectedValue = mark.StudentID;
            comboBoxSubject.SelectedValue = mark.SubjectID;
            comboBoxExam.SelectedValue = mark.ExamID;
            textBoxMarksObtained.Text = mark.MarksObtained.ToString();
            textBoxGrade.Text = mark.Grade;
            btnAdd.Text = "Update";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
