using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class LecturerRepository : ILecturerRepository
    {
        public int CreateLecturer(Lecturer lecturer)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Lecturers (UserID, Name, NIC, Phone, Address, Email, DepartmentID, CreatedAt, UpdatedAt)
                    VALUES (@UserID, @Name, @NIC, @Phone, @Address, @Email, @DepartmentID, @CreatedAt, @UpdatedAt);
                    SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@UserID", lecturer.UserID);
                cmd.Parameters.AddWithValue("@Name", lecturer.Name);
                cmd.Parameters.AddWithValue("@NIC", lecturer.NIC);
                cmd.Parameters.AddWithValue("@Phone", lecturer.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", lecturer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", lecturer.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentID", lecturer.DepartmentID);
                cmd.Parameters.AddWithValue("@CreatedAt", lecturer.CreatedAt);
                cmd.Parameters.AddWithValue("@UpdatedAt", lecturer.UpdatedAt);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Lecturers
                    SET Name = @Name,
                        NIC = @NIC,
                        Phone = @Phone,
                        Address = @Address,
                        Email = @Email,
                        DepartmentID = @DepartmentID,
                        UpdatedAt = @UpdatedAt
                    WHERE LecturerID = @LecturerID";

                cmd.Parameters.AddWithValue("@LecturerID", lecturer.LecturerID);
                cmd.Parameters.AddWithValue("@Name", lecturer.Name);
                cmd.Parameters.AddWithValue("@NIC", lecturer.NIC);
                cmd.Parameters.AddWithValue("@Phone", lecturer.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", lecturer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", lecturer.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentID", lecturer.DepartmentID.HasValue ? (object)lecturer.DepartmentID.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedAt", lecturer.UpdatedAt);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteLecturer(int lecturerId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Lecturers WHERE LecturerID = @LecturerID";
                cmd.Parameters.AddWithValue("@LecturerID", lecturerId);
                cmd.ExecuteNonQuery();
            }
        }

        public Lecturer GetLecturerById(int lecturerId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Lecturers WHERE LecturerID = @LecturerID";
                cmd.Parameters.AddWithValue("@LecturerID", lecturerId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            LecturerID = reader.GetInt32(reader.GetOrdinal("LecturerID")),
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            NIC = reader.GetString(reader.GetOrdinal("NIC")),
                            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            DepartmentID = reader.IsDBNull(reader.GetOrdinal("DepartmentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DepartmentID")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                        };
                    }
                }
            }
            return null;
        }

        public List<Lecturer> GetAllLecturers()
        {
            var lecturers = new List<Lecturer>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Lecturers";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lecturers.Add(new Lecturer
                        {
                            LecturerID = reader.GetInt32(reader.GetOrdinal("LecturerID")),
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            NIC = reader.GetString(reader.GetOrdinal("NIC")),
                            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            DepartmentID = reader.IsDBNull(reader.GetOrdinal("DepartmentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DepartmentID")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                        });
                    }
                }
            }
            return lecturers;
        }
        public Lecturer GetLecturerByUserId(int userId)
        {
            Lecturer lecturer = null;
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT l.*, d.DepartmentName, u.Username 
            FROM Lecturers l
            LEFT JOIN Departments d ON l.DepartmentID = d.DepartmentID
            LEFT JOIN Users u ON l.UserID = u.UserID
            WHERE l.UserID = @UserID";

                cmd.Parameters.AddWithValue("@UserID", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            LecturerID = reader.GetInt32(reader.GetOrdinal("LecturerID")),
                            Name = reader["Name"].ToString(),
                            NIC = reader["NIC"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            DepartmentID = reader["DepartmentID"] != DBNull.Value ? Convert.ToInt32(reader["DepartmentID"]) : (int?)null,
                            DepartmentName = reader["DepartmentName"]?.ToString(),
                            UserID = Convert.ToInt32(reader["UserID"]),
                           
                            CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()),
                            UpdatedAt = DateTime.Parse(reader["UpdatedAt"].ToString())
                        };
                    }
                }
            }

            return lecturer;
        }
    }
}

