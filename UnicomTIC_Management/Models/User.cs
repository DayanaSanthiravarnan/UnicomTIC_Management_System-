using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Models
{
    
        internal class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string NIC { get; set; }
            public UserRole Role { get; set; }           
        }
    
}
