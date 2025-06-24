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
    public partial class TimetableForm : Form
    {
        private readonly TimetableController _timetableController;
        private readonly CourseController _courseController;
        private readonly SubjectController _subjectController;
        private readonly LecturerController _lecturerController;
        private readonly RoomController _roomController;
        private readonly MainGroupController _mainGroupController;
        private readonly SubGroupController _subGroupController;
        private readonly TimeSlotController _timeSlotController;

        private int selectedTimetableId = -1;



        public TimetableForm()
        {
            InitializeComponent();

            _courseController = new CourseController(new CourseService(new CourseRepository()));
            _subjectController = new SubjectController(new SubjectService(new SubjectRepository()));
            _lecturerController = new LecturerController(new LecturerService(new LecturerRepository()));
            _roomController = new RoomController(new RoomService(new RoomRepository()));
            _mainGroupController = new MainGroupController(new MainGroupService(new MainGroupRepository()));
            _subGroupController = new SubGroupController(new SubGroupService(new SubGroupRepository()));
            _timeSlotController = new TimeSlotController(new TimeSlotService(new TimeSlotRepository()));
            _timetableController = new TimetableController(new TimetableService(new TimetableRepository()));
        }
    
       

       

        private void ClearFields()
        {
           
        }
       
        private void LoadCombos()
        {
            cmbCourse.DataSource = _courseController.GetAllCourses();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = -1;

            cmbSubject.DataSource = _subjectController.GetAllSubjects();
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.SelectedIndex = -1;

            cmbLecturer.DataSource = _lecturerController.GetAllLecturers();
            cmbLecturer.DisplayMember = "Name";
            cmbLecturer.ValueMember = "LecturerID";
            cmbLecturer.SelectedIndex = -1;

            cmbRoom.DataSource = _roomController.GetAllRooms();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
            cmbRoom.SelectedIndex = -1;

            cmbMainGroup.DataSource = _mainGroupController.GetAllMainGroup();
            cmbMainGroup.DisplayMember = "GroupCode";
            cmbMainGroup.ValueMember = "MainGroupID";
            cmbMainGroup.SelectedIndex = -1;

            cmbSubGroup.DataSource = _subGroupController.GetAllSubGroups();
            cmbSubGroup.DisplayMember = "SubGroupName";
            cmbSubGroup.ValueMember = "SubGroupID";
            cmbSubGroup.SelectedIndex = -1;

            cmbStartSlot.DataSource = _timeSlotController.GetAllTimeSlots();
            cmbStartSlot.DisplayMember = "StartTime";
           
            cmbStartSlot.ValueMember = "SlotID";
            cmbStartSlot.SelectedIndex = -1;

            cmbStartSlot.DataSource = _timeSlotController.GetAllTimeSlots();
            
            comboBox1.DisplayMember = "EndTime";
            cmbStartSlot.ValueMember = "SlotID";
            cmbStartSlot.SelectedIndex = -1;



            cmbDay.Items.Clear();
            cmbDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            cmbDay.SelectedIndex = -1;
        }

        private void LoadTimetableData()
        {
            dgvTimetables.DataSource = _timetableController.GetAllTimetables();
            dgvTimetables.DataSource = "CourseName";
            dgvTimetables.ClearSelection();
            selectedTimetableId = -1;
        }

        private void ClearForm()
        {
            cmbCourse.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbLecturer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbMainGroup.SelectedIndex = -1;
            cmbSubGroup.SelectedIndex = -1;
            cmbStartSlot.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;
            txtYear.Clear();
            txtSemester.Clear();
            selectedTimetableId = -1;
        }

        private TimetableDTO GetTimetableDTOFromForm()
        {
            return new TimetableDTO
            {
                CourseID = Convert.ToInt32(cmbCourse.SelectedValue),
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue),
                LecturerID = Convert.ToInt32(cmbLecturer.SelectedValue),
                RoomID = Convert.ToInt32(cmbRoom.SelectedValue),
                MainGroupID = Convert.ToInt32(cmbMainGroup.SelectedValue),
                SubGroupID = Convert.ToInt32(cmbSubGroup.SelectedValue),
                SlotID = Convert.ToInt32(cmbStartSlot.SelectedValue),
                DayOfWeek = cmbDay.Text,
                AcademicYear = txtYear.Text.Trim(),
                Semester = txtSemester.Text.Trim()
            };
        }




        private void TimetableForm_Load(object sender, EventArgs e)
        {
            LoadCombos();      
            LoadTimetableGrid();
        }
        private void LoadTimetableGrid()
        {
            var timetables = _timetableController.GetAllTimetables();
            dgvTimetables.DataSource = timetables;

            if (dgvTimetables.Columns.Contains("TimetableID"))
                dgvTimetables.Columns["TimetableID"].Visible = false;
        }

        private void dgvTimetable_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = GetTimetableDTOFromForm();
                if (_timetableController.IsSlotOccupied(dto))
                {
                    MessageBox.Show("Selected time slot is already occupied.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _timetableController.AddTimetable(dto);  // ✅ returns void now
                MessageBox.Show("Timetable added successfully!");
                ClearForm();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Select a timetable to update.");
                return;
            }

            var dto = GetTimetableDTOFromForm();
            dto.TimetableID = selectedTimetableId;

            if (_timetableController.IsSlotOccupied(dto, selectedTimetableId))
            {
                MessageBox.Show("Time slot conflict.");
                return;
            }

            _timetableController.UpdateTimetable(dto);
            MessageBox.Show("Timetable updated.");
            LoadTimetableData();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId != -1)
            {
                _timetableController.DeleteTimetable(selectedTimetableId);
                MessageBox.Show("Timetable deleted.");
                LoadTimetableData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Select a timetable to delete.");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
       
      

        private void dgvTimetables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTimetables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTimetables.Rows[e.RowIndex];
                selectedTimetableId = Convert.ToInt32(row.Cells["TimetableID"].Value);

                cmbCourse.SelectedValue = row.Cells["CourseID"].Value;
                cmbSubject.SelectedValue = row.Cells["SubjectID"].Value;
                cmbLecturer.SelectedValue = row.Cells["LecturerID"].Value;
                cmbRoom.SelectedValue = row.Cells["RoomID"].Value;
                cmbMainGroup.SelectedValue = row.Cells["MainGroupID"].Value;
                cmbSubGroup.SelectedValue = row.Cells["SubGroupID"].Value;
                cmbStartSlot.SelectedValue = row.Cells["SlotID"].Value;
                cmbDay.Text = row.Cells["DayOfWeek"].Value.ToString();
                txtYear.Text = row.Cells["AcademicYear"].Value.ToString();
                txtSemester.Text = row.Cells["Semester"].Value.ToString();
            }
        }
      
        
    }
}

