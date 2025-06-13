using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class TopPerformer
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string Term  { get; set; }
        public double GPA { get; set; }
    }
}
