using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IUserService
    {
        int AddUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void ApproveUser(int userId);
        void RejectUser(int userId);
        void DeleteUser(int userId);
        List<UserDTO> GetAllUsers();
        List<UserDTO> GetPendingUsers();
        UserDTO GetUserById(int userId);
        UserDTO GetUserByUsernameAndPassword(string username, string password);
        UserDTO ValidateUser(string username, string password);
        bool IsUsernameTaken(string username);
    }
}
