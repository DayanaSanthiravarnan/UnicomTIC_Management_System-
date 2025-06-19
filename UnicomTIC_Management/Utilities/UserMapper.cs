using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Utilities
{
    internal static class UserMapper
    {
        public static UserDTO ToDTO(User user)
        {
            if (user == null) return null;
            return new UserDTO
            {
                UserID = user.UserID,
                Username = user.Username,
                Password = user.Password,
                NIC = user.NIC,
                Role = user.Role,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public static User ToEntity(UserDTO dto)
        {
            if (dto == null) return null;
            return new User
            {
                UserID = dto.UserID,
                Username = dto.Username,
                Password = dto.Password,
                NIC = dto.NIC,
                Role = dto.Role,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }

        public static List<UserDTO> ToDTOList(IEnumerable<User> users)
        {
            return users?.Select(ToDTO).ToList() ?? new List<UserDTO>();
        }

        public static List<User> ToEntityList(IEnumerable<UserDTO> dtos)
        {
            return dtos?.Select(ToEntity).ToList() ?? new List<User>();
        }
    }
}
