using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Mark
    {
        public int MarksID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int ExamID { get; set; }
        public int MarksObtained { get; set; }

    }
}
