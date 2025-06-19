using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Models
{
    public class Student
    {

        public int StudentID { get; set; }
        public string Name { get; set; } 
        public string NIC { get; set; } 
        public string Address { get; set; } 
        public string ContactNo { get; set; } 
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public int MainGroupID { get; set; }
        public int SubGroupID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserStatus Status { get; set; }

    }
}
