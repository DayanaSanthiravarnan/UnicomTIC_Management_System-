using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models.DTOs
{
    public class MainGroupDTO
    {
        public int MainGroupID { get; set; }
        public string GroupCode { get; set; }
        public string Description { get; set; }
        public int StudentID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
