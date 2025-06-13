using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Submission
    {
        public int SubmissionID { get; set; }
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public string SubmittedAt { get; set; }
    }
}
