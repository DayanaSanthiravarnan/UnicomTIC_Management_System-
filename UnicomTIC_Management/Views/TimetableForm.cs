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

            var courseRepo = new CourseRepository();
            var courseService = new CourseService(courseRepo);
            _courseController = new CourseController(courseService);

            var subjectRepo = new SubjectRepository();
            var subjectService = new SubjectService(subjectRepo);
            _subjectController = new SubjectController(subjectService);

            var lecturerRepo = new LecturerRepository();
            var lecturerService = new LecturerService(lecturerRepo);
            _lecturerController = new LecturerController(lecturerService);

            var roomRepo = new RoomRepository();
            var roomService = new RoomService(roomRepo);
            _roomController = new RoomController(roomService);

            var mainGroupRepo = new MainGroupRepository();
            var mainGroupService = new MainGroupService(mainGroupRepo);
            _mainGroupController = new MainGroupController(mainGroupService);

            var subGroupRepo = new SubGroupRepository();
            var subGroupService = new SubGroupService(subGroupRepo);
            _subGroupController = new SubGroupController(subGroupService);

            var slotRepo = new TimeSlotRepository();
            var slotService = new TimeSlotService(slotRepo);
            _slotController = new TimeSlotController(slotService);

            var timetableRepo = new TimetableRepository();
            var timetableService = new TimetableService(timetableRepo);
            _timetableController = new TimetableController(timetableService);
        }
        private void LoadCombos()
        {
            // Courses
            var courses = _courseController.GetAllCourses();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = -1;

            // Subjects
            var subjects = _subjectController.GetAllSubjects();
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.SelectedIndex = -1;

            // Lecturers
            var lecturers = _lecturerController.GetAllLecturers();
            cmbLecturer.DataSource = lecturers;
            cmbLecturer.DisplayMember = "LecturerName";
            cmbLecturer.ValueMember = "LecturerID";
            cmbLecturer.SelectedIndex = -1;

            // Rooms
            var rooms = _roomController.GetAllRooms();
            cmbRoom.DataSource = rooms;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
            cmbRoom.SelectedIndex = -1;

            // Main Groups
            var mainGroups = _mainGroupController.GetAllMainGroups();
            cmbMainGroup.DataSource = mainGroups;
            cmbMainGroup.DisplayMember = "MainGroupName";
            cmbMainGroup.ValueMember = "MainGroupID";
            cmbMainGroup.SelectedIndex = -1;

            // Sub Groups
            var subGroups = _subGroupController.GetAllSubGroups();
            cmbSubGroup.DataSource = subGroups;
            cmbSubGroup.DisplayMember = "SubGroupName";
            cmbSubGroup.ValueMember = "SubGroupID";
            cmbSubGroup.SelectedIndex = -1;

            // Time Slots
            var timeSlots = _timeSlotController.GetAllTimeSlots();
            cmbSlot.DataSource = timeSlots;
            cmbSlot.DisplayMember = "SlotName"; // Adjust according to your TimeSlot DTO property
            cmbSlot.ValueMember = "SlotID";
            cmbSlot.SelectedIndex = -1;

            // Days
            cmbDay.Items.Clear();
            cmbDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            cmbDay.SelectedIndex = -1;
        }
        

       

        private void ClearFields()
        {
            cmbCourse.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbLecturer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbMainGroup.SelectedIndex = -1;
            cmbSubGroup.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;
            cmbSlot.SelectedIndex = -1;
            txtYear.Clear();
            txtSemester.Clear();
        }
        private void LoadTimetables()
        {
            var list = _timetableController.GetAllTimetables();
            dataGridView1.DataSource = list;
            selectedTimetableId = -1;
        }




        private void TimetableForm_Load(object sender, EventArgs e)
        {
            cmbCourse.DataSource = _courseController.GetAllCourses();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";

            cmbSubject.DataSource = _subjectController.GetAllSubjects();
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";

            cmbLecturer.DataSource = _lecturerController.GetAllLecturers();
            cmbLecturer.DisplayMember = "LecturerName";
            cmbLecturer.ValueMember = "LecturerID";

            cmbRoom.DataSource = _roomController.GetAllRooms();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";

            cmbMainGroup.DataSource = _mainGroupController.GetAllMainGroup();
            cmbMainGroup.DisplayMember = "GroupName";
            cmbMainGroup.ValueMember = "MainGroupID";

            cmbSubGroup.DataSource = _subGroupController.GetAllSubGroups();
            cmbSubGroup.DisplayMember = "SubGroupName";
            cmbSubGroup.ValueMember = "SubGroupID";

            cmbSlot.DataSource = _slotController.GetAllTimeSlots();
            cmbSlot.DisplayMember = "DisplayTime";
            cmbSlot.ValueMember = "SlotID";
        }

        private void dgvTimetable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTimetables.SelectedRows.Count > 0)
            {
                var row = dgvTimetables.SelectedRows[0];
                selectedTimetableId = Convert.ToInt32(row.Cells["TimetableID"].Value);

                cmbCourse.SelectedValue = row.Cells["CourseID"].Value;
                cmbSubject.SelectedValue = row.Cells["SubjectID"].Value;
                cmbLecturer.SelectedValue = row.Cells["LecturerID"].Value;
                cmbRoom.SelectedValue = row.Cells["RoomID"].Value;
                cmbSlot.SelectedValue = row.Cells["SlotID"].Value;
                cmbMainGroup.SelectedValue = row.Cells["MainGroupID"].Value;
                cmbSubGroup.SelectedValue = row.Cells["SubGroupID"].Value;
                cmbDay.Text = row.Cells["DayOfWeek"].Value.ToString();
                txtYear.Text = row.Cells["AcademicYear"].Value.ToString();
                txtSemester.Text = row.Cells["Semester"].Value.ToString();
            }
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

                int id = _timetableController.AddTimetable(dto);
                if (id > 0)
                {
                    MessageBox.Show("Timetable added successfully!");
                    ClearForm();
                    LoadTimetables();
                }
                else
                {
                    MessageBox.Show("Failed to add timetable.");
                }
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
                MessageBox.Show("Please select a timetable entry to update.");
                return;
            }

            var dto = new TimetableDTO
            {
                TimetableID = selectedTimetableId,
                CourseID = Convert.ToInt32(cmbCourse.SelectedValue),
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue),
                LecturerID = Convert.ToInt32(cmbLecturer.SelectedValue),
                RoomID = Convert.ToInt32(cmbRoom.SelectedValue),
                SlotID = Convert.ToInt32(cmbSlot.SelectedValue),
                MainGroupID = Convert.ToInt32(cmbMainGroup.SelectedValue),
                SubGroupID = Convert.ToInt32(cmbSubGroup.SelectedValue),
                DayOfWeek = cmbDay.Text,
                AcademicYear = txtYear.Text.Trim(),
                Semester = txtSemester.Text.Trim()
            };

            if (_timetableController.IsSlotOccupied(dto, selectedTimetableId))
            {
                MessageBox.Show("Slot is already occupied for another timetable.");
                return;
            }

            _timetableController.UpdateTimetable(dto);
            MessageBox.Show("Timetable updated.");
            LoadTimetableGrid();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (selectedTimetableId != null)
            {
                _timetableController.DeleteTimetable(selectedTimetableId.Value);
                MessageBox.Show("Timetable deleted successfully.");
                ClearForm();
                LoadTimetableData();
            }
            else
            {
                MessageBox.Show("Please select a timetable to delete.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private bool ValidateInput(out TimeSpan start, out TimeSpan end)
        {
            start = dtpStartTime.Value.TimeOfDay;
            end = dtpEndTime.Value.TimeOfDay;

            if (start >= end)
            {
                MessageBox.Show("Start time must be before end time.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtYear.Text) || string.IsNullOrWhiteSpace(txtSemester.Text))
            {
                MessageBox.Show("Academic Year and Semester are required.");
                return false;
            }

            return true;
        }

        private TimetableDTO CreateDto(TimeSpan start, TimeSpan end)
        {
            return new TimetableDTO
            {
                LecturerID = (int)cmbLecturer.SelectedValue,
                CourseID = (int)cmbCourse.SelectedValue,
                SubjectID = (int)cmbSubject.SelectedValue,
                RoomID = (int)cmbRoom.SelectedValue,
                MainGroupID = (int)cmbMainGroup.SelectedValue,
               
                DayOfWeek = cmbDay.SelectedItem.ToString(),
                StartTime = start,
                EndTime = end,
                AcademicYear = txtYear.Text.Trim(),
                Semester = txtSemester.Text.Trim()
            };
        }
        private void LoadTimetableGrid()
        {
            var timetables = _timetableController.GetAllTimetables();
            dgvTimetables.DataSource = timetables;
            dgvTimetables.Columns["TimetableID"].Visible = false;
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
                cmbSlot.SelectedValue = row.Cells["SlotID"].Value;
                cmbDay.Text = row.Cells["Day"].Value.ToString();
                txtYear.Text = row.Cells["Year"].Value.ToString();
                txtSemester.Text = row.Cells["Semester"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            cmbCourse.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbLecturer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbMainGroup.SelectedIndex = -1;
            cmbSubGroup.SelectedIndex = -1;
            cmbSlot.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;

            selectedTimetableId = -1;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}

