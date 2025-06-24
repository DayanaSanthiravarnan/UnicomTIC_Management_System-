using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }  // ← Joined from Students table
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }  // ← Joined from Subjects table
        public string Date { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
    }
}
