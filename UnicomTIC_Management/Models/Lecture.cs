using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Lecture
    {
        public int LecturesID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
    }
}
