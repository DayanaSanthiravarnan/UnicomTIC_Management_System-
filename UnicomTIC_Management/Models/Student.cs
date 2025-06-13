using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string DateOfBirth { get; set; } 
        public string Gender { get; set; }
        public string EnrollmentDate { get; set; } 
        public int CourseID { get; set; }
        public string CourceName { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int MainGroupID { get; set; }
        public string GroupCode { get; set; }
        public int SubGroupID { get; set; }
        public string SubGroupName { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }

        public Student()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
