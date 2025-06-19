using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public int AddUser(User user)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Users (Username, Password, NIC, Role, Status)
                        VALUES (@Username, @Password, @NIC, @Role, @Status);
                        SELECT last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@NIC", user.NIC);
                    cmd.Parameters.AddWithValue("@Role", user.Role.ToString());
                    cmd.Parameters.AddWithValue("@Status", user.Status);

                    long id = (long)cmd.ExecuteScalar();
                    return (int)id;
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error while adding user.", ex);
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Users
                        SET Username = @Username,
                            Password = @Password,
                            NIC = @NIC,
                            Role = @Role
                        WHERE UserID = @UserID";

                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@NIC", user.NIC);
                    cmd.Parameters.AddWithValue("@Role", user.Role.ToString());
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error while updating user.", ex);
            }
        }

        public void UpdateUserStatus(int userId, UserStatus status)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Users SET Status = @Status WHERE UserID = @UserID";
                    cmd.Parameters.AddWithValue("@Status", status.ToString());
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error while updating user status.", ex);
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Users WHERE UserID = @UserID";
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error while deleting user.", ex);
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Users WHERE UserID = @UserID";
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error retrieving user by ID.", ex);
            }
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUser(reader);
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error retrieving user by credentials.", ex);
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Users";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(MapUser(reader));
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error retrieving all users.", ex);
            }
            return users;
        }

        // Optional: Get only Pending users
        public List<User> GetUsersByStatus(string status)
        {
            var users = new List<User>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Users WHERE Status = @Status";
                    cmd.Parameters.AddWithValue("@Status", status);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(MapUser(reader));
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error retrieving users by status.", ex);
            }
            return users;
        }

        private User MapUser(SQLiteDataReader reader)
        {
            return new User
            {
                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                Username = reader.GetString(reader.GetOrdinal("Username")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                NIC = reader.GetString(reader.GetOrdinal("NIC")),
                Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString(reader.GetOrdinal("Role"))),
                Status = (UserStatus)Enum.Parse(typeof(UserStatus), reader.GetString(reader.GetOrdinal("Status"))),
                CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                UpdatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("UpdatedAt")))
            };
        }
    }
}






