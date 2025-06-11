using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Enums;

namespace UnicomTIC_Management.DTOs
{
    internal class User_Role
    {
       

        public int UserID { get; set; }
        public string Username { get; set; }
       
        public string NIC { get; set; }
        public User_enum Role { get; set; }
    }
}
