using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class UserController
    {

        private readonly IUserService _userService;

        internal UserController(IUserService userService)  // public constructor
        {
            _userService = userService;
        }

        // Create user after validating admin credentials
        public int CreateUser(UserDTO newUser)
        {
          /*  var adminUser = _userService.ValidateUser(newUser.Username, newUser.Password);
            if (adminUser == null || adminUser.Role != Models.Enums.UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Only admin users can create new users.");
            }*/

            int newUserId = _userService.AddUser(newUser);
            Console.WriteLine($"User created successfully with UserID: {newUserId}");
            return newUserId;
        }
        public void UpdateUser(UserDTO userDTO)
        {
            _userService.UpdateUser(userDTO);
            Console.WriteLine($"User with ID {userDTO.UserID} updated.");
        }

        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            Console.WriteLine($"User with ID {userId} deleted.");
        }

        public UserDTO GetUser(int userId)
        {
            return _userService.GetUserById(userId);
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
        public void ApproveUser(int userId)
        {
            _userService.ApproveUser(userId);
        }

        public void RejectUser(int userId)
        {
            _userService.RejectUser(userId);
        }
        public bool IsUsernameTaken(string username)
        {
            try
            {
                return _userService.IsUsernameTaken(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking username: {ex.Message}");
                return false; // or true, depending on your default policy
            }
        }
        public User Login(string username, string password)
        {
            return _userService.ValidateLogin(username, password);
        }


        /*internal int CreateUser(UserDTO pendingUser)
        {
            throw new NotImplementedException();
        }*/
    }
}


        
            

        
