using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models.DTOs
{
    internal class TimetableDTO
    {
        public int TimetableID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int LecturerID { get; set; }
        public string LecturerName { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int SlotID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MainGroupID { get; set; }
        public string MainGroupName { get; set; }
        public int SubGroupID { get; set; }
        public string SubGroupName { get; set; }
        public string DayOfWeek { get; set; }
        public string AcademicYear { get; set; }
        public string Semester { get; set; }
    }
}
