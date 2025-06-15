using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models.DTOs
{
    internal class ExamDTO
    {
        
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } 
        public string ExamDate { get; set; }
        public string ExamType { get; set; }
        public int MaxMarks { get; set; }
    }
}

