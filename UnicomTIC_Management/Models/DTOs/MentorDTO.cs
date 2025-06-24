using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models.DTOs
{
    internal class MentorDTO
    {
        public int MentorID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public int DepartmentID { get; set; }
        public int UserID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DepartmentName { get; set; }
    }
}
