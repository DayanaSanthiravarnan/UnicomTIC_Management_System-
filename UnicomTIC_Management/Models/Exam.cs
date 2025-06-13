using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Exam
    {
        public int ExamsID {  get; set; }
        public string ExamsName { get; set; }
        public int SubjectID { get; set; }
        public string ExamDate { get; set; }
    }
}
