using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.DTOs;

namespace UnicomTIC_Management.Models
{
    internal class UserMapper
    {
        public static User_Role ToDto(User user)
        {
            return new User_Role
            {
                UserID = user.UserID,
                Username = user.Username,
                NIC = user.NIC,
                Role = user.Role,
            };
        }
        public static User ToEntity(User_Role dto, string password)
        {
            return new User
            {
                UserID = dto.UserID,
                Username = dto.Username,
                Password = password,
                NIC = dto.NIC,

                Role = dto.Role
            };
        }
    }
}
