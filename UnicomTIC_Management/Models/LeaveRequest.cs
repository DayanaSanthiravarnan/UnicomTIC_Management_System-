using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class LeaveRequest
    {
        public int LeaveID { get; set; }
        public int StaffID { get; set; }
        public int StudentID { get; set; }
        public int LecturerID { get; set; }
        public string StartDate  { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }


    }
}
