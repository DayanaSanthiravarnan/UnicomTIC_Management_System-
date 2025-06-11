using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Enums;

namespace UnicomTIC_Management.Models
{
    
        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string NIC { get; set; }
            public User_enum Role { get; set; }
      
           
        }
    
}
