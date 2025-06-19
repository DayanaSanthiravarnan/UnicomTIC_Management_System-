using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.Enums;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        int AddUser(User user);
        void UpdateUser(User user);
        void UpdateUserStatus(int userId, UserStatus status);
        void DeleteUser(int userId);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByUsernameAndPassword(string username, string password);
    }
}
