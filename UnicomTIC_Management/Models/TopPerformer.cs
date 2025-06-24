using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class TopPerformer
    {
        public int TopPerformerID { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int MarksObtained { get; set; }
        public string Grade { get; set; }
        public string RecordedDate { get; set; }

        // Extra info for display
        public string StudentName { get; set; }
        public string ExamName { get; set; }
    }
}
