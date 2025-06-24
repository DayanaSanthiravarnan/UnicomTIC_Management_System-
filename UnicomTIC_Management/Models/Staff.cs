using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Models
{
    internal class Staff
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public int? DepartmentID { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DepartmentName { get; set; }

    }
}
