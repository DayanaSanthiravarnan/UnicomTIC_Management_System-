using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models.DTOs
{
    internal class TopPerformerDTO
    {
        public int TopPerformerID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int MarksObtained { get; set; }
        public string Grade { get; set; }
        public string RecordedDate { get; set; }
    }
}
