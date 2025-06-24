using System;
using System.Collections.Generic;
using System.Linq;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public int AddUser(UserDTO userDTO)
        {
            if (userDTO == null) throw new ArgumentNullException(nameof(userDTO));

            if (string.IsNullOrWhiteSpace(userDTO.Username))
                throw new ArgumentException("Username is required.");
            if (string.IsNullOrWhiteSpace(userDTO.Password))
                throw new ArgumentException("Password is required.");
            if (string.IsNullOrWhiteSpace(userDTO.NIC))
                throw new ArgumentException("NIC is required.");

            if (!Enum.IsDefined(typeof(UserRole), userDTO.Role))
                throw new ArgumentException("Invalid user role.");

            userDTO.Status = UserStatus.Pending; 

            var user = UserMapper.ToEntity(userDTO);
            return _repository.AddUser(user);
        }

        public void UpdateUser(UserDTO userDTO)
        {
            if (userDTO == null) throw new ArgumentNullException(nameof(userDTO));
            if (userDTO.UserID <= 0) throw new ArgumentException("Valid UserID is required.");

            var user = UserMapper.ToEntity(userDTO);
            _repository.UpdateUser(user);
        }

        public void ApproveUser(int userId)
        {
            if (userId <= 0) throw new ArgumentException("Invalid UserID for approval.");
            _repository.UpdateUserStatus(userId, UserStatus.Approved);
        }

        public void RejectUser(int userId)
        {
            if (userId <= 0) throw new ArgumentException("Invalid UserID for rejection.");
            _repository.UpdateUserStatus(userId, UserStatus.Rejected);
        }

        public void DeleteUser(int userId)
        {
            if (userId <= 0) throw new ArgumentException("Invalid UserID for deletion.");
            _repository.DeleteUser(userId);
        }

        public List<UserDTO> GetAllUsers()
        {
            return UserMapper.ToDTOList(_repository.GetAllUsers());
        }

        public List<UserDTO> GetPendingUsers()
        {
            var users = _repository.GetAllUsers()
                                   .Where(u => u.Status == UserStatus.Pending);
            return UserMapper.ToDTOList(users);
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _repository.GetUserById(userId);
            return UserMapper.ToDTO(user);
        }

        public UserDTO GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _repository.GetUserByUsernameAndPassword(username, password);
            return UserMapper.ToDTO(user);
        }
        public UserDTO ValidateUser(string username, string password)
        {
            var user = _repository.GetUserByUsernameAndPassword(username, password);
            return UserMapper.ToDTO(user);
        }
        public bool IsUsernameTaken(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return _repository.DoesUsernameExist(username);
        }
        public User ValidateLogin(string username, string password)
        {
            return _repository.GetUserByUsernameAndPassword(username, password);
        }

    }

}

