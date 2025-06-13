using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Complaint
    {
        public int ComplaintID {  get; set; }
        public int ComplaintByUserID { get; set; }
        public int ComplaintAgainstByUserID { get; set; }
        public int ComplaintText { get; set; }
        public int SubmittedAt { get; set; }


    }
}
